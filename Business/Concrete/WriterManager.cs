using Business.Abstract;
using Business.Constants;
using Business.Mapping;
using Business.ValidationRules.FluentValidation;
using Business.ValidationRules.FluentValidation.WriterValidation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dtos.Writer;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.UnitOfWork;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        private readonly IUnitOfWork _unitOfWork;

        public WriterManager(IWriterDal writerDal,IUnitOfWork unitOfWork)
        {
            _writerDal = writerDal;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<object>> AddAsync(WriterAddDto writer)
        {
            await ValidationTool.ValidateAsync(new WriterValidator(), writer);

            await _writerDal.AddAsync(ObjectMapper.Mapper.Map<Writer>(writer));
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.WriterAdded);
        }

        public async Task<IResult> DeleteAsync(Writer writer)
        {
            var businessRules = BusinessRules.Run(CheckIfWriterId(writer.WriterId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _writerDal.Delete(writer);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.WriterDeleted);
        }

        public async Task<IDataResult<Writer>> GetByWriterEmailAsync(string email)
        {
            return new SuccessDataResult<Writer>(await _writerDal.GetAsync(x => x.Mail == email));
        }

        public async Task<IDataResult<List<Writer>>> GetAllAsync()
        {
            var result = await _writerDal.GetAllAsync();
            return new SuccessDataResult<List<Writer>>(result);
        }

        public async Task<IDataResult<Writer>> GetByIdAsync(int id)
        {
            var result = await _writerDal.GetAsync(x => x.WriterId == id);
            if (result is not null)
            {
                return new SuccessDataResult<Writer>(result);
            }
            return new ErrorDataResult<Writer>(Messages.WriterNotFound);
        }

        public async Task<IResult> UpdateAsync(WriterUpdateDto writer)
        {
            await ValidationTool.ValidateAsync(new WriterUpdateValidator(), writer);

            _writerDal.Update(ObjectMapper.Mapper.Map<Writer>(writer));
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.WriterUpdated);
        }

        public async Task<IDataResult<object>> UserLoginAsync(Writer writer)
        {
            await ValidationTool.ValidateAsync(new WriterLoginValidator(), writer);

            return new SuccessDataResult<object>();
        }

        private IResult CheckIfWriterId(int writerId)
        {
            var result = _writerDal.GetAsync(x => x.WriterId == writerId).Result;
            return result is null
                ? new ErrorResult(Messages.WriterNotFound)
                : null;
        }

    }
}

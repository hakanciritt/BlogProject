using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public async Task<IDataResult<object>> AddAsync(Writer writer)
        {
            var validationResult = ValidationTool.Validate(new WriterValidator(), writer);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            await _writerDal.AddAsync(writer);
            return new SuccessDataResult<object>(Messages.WriterAdded);
        }

        public async Task<IResult> DeleteAsync(Writer writer)
        {
            var businessRules = BusinessRules.Run(CheckIfWriterId(writer.WriterId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            await _writerDal.DeleteAsync(writer);
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

        public async Task<IResult> UpdateAsync(Writer writer)
        {
            await _writerDal.UpdateAsync(writer);
            return new SuccessResult(Messages.WriterUpdated);
        }

        public async Task<IDataResult<object>> UserLoginAsync(Writer writer)
        {
            var validationResult = ValidationTool.Validate(new WriterLoginValidator(), writer);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }

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

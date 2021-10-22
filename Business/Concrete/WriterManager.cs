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
        public IDataResult<object> Add(Writer writer)
        {
            var validationResult = ValidationTool.Validate(new WriterValidator(), writer);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            _writerDal.Add(writer);
            return new SuccessDataResult<object>(Messages.WriterAdded);
        }

        public IResult Delete(Writer writer)
        {
            var businessRules = BusinessRules.Run(CheckIfWriterId(writer.WriterId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _writerDal.Delete(writer);
            return new SuccessResult(Messages.WriterDeleted);
        }

        public IDataResult<Writer> GetByWriterEmail(string email)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(x => x.Mail == email));
        }

        public IDataResult<List<Writer>> GetAll()
        {
            var result = _writerDal.GetAll();
            return new SuccessDataResult<List<Writer>>(result);
        }

        public IDataResult<Writer> GetById(int id)
        {
            var result = _writerDal.Get(x => x.WriterId == id);
            if (result is not null)
            {
                return new SuccessDataResult<Writer>(result);
            }
            return new ErrorDataResult<Writer>(Messages.WriterNotFound);
        }

        public IResult Update(Writer writer)
        {
            _writerDal.Update(writer);
            return new SuccessResult(Messages.WriterUpdated);
        }

        private IResult CheckIfWriterId(int writerId)
        {
            var result = _writerDal.Get(x => x.WriterId == writerId);
            return result is null
                ? new ErrorResult(Messages.WriterNotFound)
                : null;
        }

        public IDataResult<object> UserLogin(Writer writer)
        {
            var validationResult = ValidationTool.Validate(new WriterLoginValidator(), writer);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }

            return new SuccessDataResult<object>();
        }
    }
}

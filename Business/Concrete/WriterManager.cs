using Business.Abstract;
using Business.Constants;
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
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult(Messages.WriterAdded);
        }

        public IResult Delete(Writer writer)
        {
            _writerDal.Delete(writer);
            return new SuccessResult(Messages.WriterDeleted);
        }

        public IDataResult<List<Writer>> GetAll()
        {
            var result = _writerDal.GetAll();
            return new SuccessDataResult<List<Writer>>(result);
        }

        public IDataResult<Writer> GetById(int id)
        {
            var result = _writerDal.Get(x => x.Id == id);
            if (result is not null)
            {
                return new SuccessDataResult<Writer>(result);
            }
            return new ErrorDataResult<Writer>(Messages.WriterNotFound);
        }

        public IResult Update(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}

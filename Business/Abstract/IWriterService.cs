using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        IDataResult<object> Add(Writer writer);
        IResult Delete(Writer writer);
        IResult Update(Writer writer);
        IDataResult<Writer> GetById(int id);
        IDataResult<List<Writer>> GetAll();
        IDataResult<Writer> GetByWriterEmail(string email);
        IDataResult<object> UserLogin(Writer writer);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IDataResult<object> Add(About about);
        IResult Update(About about);
        IResult Delete(About about);
        IDataResult<About> GetById(int id);
        IDataResult<List<About>> GetAll();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NatificationManager : INatificationService
    {
        private readonly INatificationDal _natificationDal;

        public NatificationManager(INatificationDal natificationDal)
        {
            _natificationDal = natificationDal;
        }
        public async Task<IDataResult<List<Natification>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Natification>>(await _natificationDal.GetAllAsync());
        }
    }
}

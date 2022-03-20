using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.UnitOfWorks;

namespace Business.Concrete
{
    public class NatificationManager : INatificationService
    {
        private readonly INatificationDal _natificationDal;
        private readonly IUnitOfWork _unitOfWork;

        public NatificationManager(INatificationDal natificationDal , IUnitOfWork unitOfWork)
        {
            _natificationDal = natificationDal;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<List<Natification>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Natification>>(await _natificationDal.GetAllAsync());
        }
    }
}

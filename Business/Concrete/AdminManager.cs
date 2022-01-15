using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IDataResult<Admin> GetById(int id)
        {
            var result = _adminDal.Get(c => c.AdminId == id);
            if (result != null)
                return new SuccessDataResult<Admin>(result);
            else
                return new ErrorDataResult<Admin>(Messages.AdminNotFound);
        }
    }
}

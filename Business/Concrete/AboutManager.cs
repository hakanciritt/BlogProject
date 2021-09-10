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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult(Messages.AboutAdded);
        }

        public IResult Delete(About about)
        {
            _aboutDal.Delete(about);
            return new SuccessResult(Messages.AboutDeleted);
        }

        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            return new SuccessResult(Messages.AboutUpdated);
        }
    }
}

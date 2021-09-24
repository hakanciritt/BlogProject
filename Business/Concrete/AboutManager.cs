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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public IDataResult<object> Add(About about)
        {
            var validationResult = ValidationTool.Validate(new AboutValidator(), about);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            _aboutDal.Add(about);
            return new SuccessDataResult<object>(Messages.AboutAdded);
        }

        public IResult Delete(About about)
        {
            var businessRules = BusinessRules.Run(CheckIfAboutId(about.AboutId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _aboutDal.Delete(about);
            return new SuccessResult(Messages.AboutDeleted);
        }

        public IDataResult<List<About>> GetAll()
        {
            var result = _aboutDal.GetAll();
            return new SuccessDataResult<List<About>>(result);
        }

        public IDataResult<About> GetById(int id)
        {
            var result = _aboutDal.Get(x => x.AboutId == id);
            return new SuccessDataResult<About>(result);
        }

        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            return new SuccessResult(Messages.AboutUpdated);
        }
        private IResult CheckIfAboutId(int aboutId)
        {
            var result = _aboutDal.Get(x => x.AboutId == aboutId);
            return result is null
                ? new ErrorResult(Messages.AboutNotFound)
                : null;
        }
    }
}

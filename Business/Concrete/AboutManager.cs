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
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public async Task<IDataResult<object>> AddAsync(About about)
        {
            var validationResult = ValidationTool.Validate(new AboutValidator(), about);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            await _aboutDal.AddAsync(about);
            return new SuccessDataResult<object>(Messages.AboutAdded);
        }

        public async Task<IResult> DeleteAsync(About about)
        {
            var businessRules = BusinessRules.Run(CheckIfAboutIdAsync(about.AboutId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            await _aboutDal.DeleteAsync(about);
            return new SuccessResult(Messages.AboutDeleted);
        }

        public async Task<IDataResult<List<About>>> GetAllAsync()
        {
            var result = await _aboutDal.GetAllAsync();
            return new SuccessDataResult<List<About>>(result);
        }

        public async Task<IDataResult<About>> GetByIdAsync(int id)
        {
            var result = await _aboutDal.GetAsync(x => x.AboutId == id);
            return new SuccessDataResult<About>(result);
        }

        public async Task<IResult> UpdateAsync(About about)
        {
            await _aboutDal.UpdateAsync(about);
            return new SuccessResult(Messages.AboutUpdated);
        }

        private IResult CheckIfAboutIdAsync(int aboutId)
        {
            var result = _aboutDal.GetAsync(x => x.AboutId == aboutId).Result;
            return result is null
                ? new ErrorResult(Messages.AboutNotFound)
                : null;
        }
    }
}

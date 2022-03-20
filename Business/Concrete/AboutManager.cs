using Business.Abstract;
using Business.Constants;
using Business.Mapping;
using Business.ValidationRules.FluentValidation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dtos.About;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.UnitOfWorks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IUnitOfWork _unitOfWork;

        public AboutManager(IAboutDal aboutDal , IUnitOfWork unitOfWork)
        {
            _aboutDal = aboutDal;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<object>> AddAsync(About about)
        {
            await ValidationTool.ValidateAsync(new AboutValidator(), about);

            await _aboutDal.AddAsync(about);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.AboutAdded);
        }

        public async Task<IResult> DeleteAsync(About about)
        {
            var businessRules = BusinessRules.Run(CheckIfAboutIdAsync(about.AboutId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _aboutDal.Delete(about);
            return new SuccessResult(Messages.AboutDeleted);
        }

        public async Task<IDataResult<List<AboutDto>>> GetAllAsync()
        {
            var result = await _aboutDal.GetAllAsync();
            return new SuccessDataResult<List<AboutDto>>(ObjectMapper.Mapper.Map<List<AboutDto>>(result));
        }

        public async Task<IDataResult<About>> GetByIdAsync(int id)
        {
            var result = await _aboutDal.GetAsync(x => x.AboutId == id);
            return new SuccessDataResult<About>(result);
        }

        public async Task<IResult> UpdateAsync(About about)
        {
            _aboutDal.Update(about);
            await _unitOfWork.CommitAsync();
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

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Threading.Tasks;
using DataAccess.UnitOfWork;

namespace Business.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetter;
        private readonly IUnitOfWork _unitOfWork;

        public NewsLetterManager(INewsLetterDal newsLetter, IUnitOfWork unitOfWork)
        {
            _newsLetter = newsLetter;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<object>> AddNewsLetterAsync(NewsLetter newsLetter)
        {
            await ValidationTool.ValidateAsync(new NewsLetterValidator(), newsLetter);

            newsLetter.MailStatus = true;
            await _newsLetter.AddAsync(newsLetter);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.RegistrationSuccessful);
        }
    }
}

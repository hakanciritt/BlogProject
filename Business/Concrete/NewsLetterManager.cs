using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetter;

        public NewsLetterManager(INewsLetterDal newsLetter)
        {
            _newsLetter = newsLetter;
        }

        public async Task<IDataResult<object>> AddNewsLetterAsync(NewsLetter newsLetter)
        {
            ValidationTool.Validate(new NewsLetterValidator(), newsLetter);

            newsLetter.MailStatus = true;
            await _newsLetter.AddAsync(newsLetter);
            return new SuccessDataResult<object>(Messages.RegistrationSuccessful);
        }
    }
}

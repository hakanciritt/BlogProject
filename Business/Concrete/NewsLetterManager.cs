using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
            var validationResult = ValidationTool.Validate(new NewsLetterValidator(), newsLetter);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            newsLetter.MailStatus = true;
            await _newsLetter.AddAsync(newsLetter);
            return new SuccessDataResult<object>(Messages.RegistrationSuccessful);
        }
    }
}

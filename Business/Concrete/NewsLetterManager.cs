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
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetter;

        public NewsLetterManager(INewsLetterDal newsLetter)
        {
            _newsLetter = newsLetter;
        }

        public IDataResult<object> AddNewsLetter(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsLetter.Add(newsLetter);
            return new SuccessDataResult<object>(Messages.Added);
        }
    }
}

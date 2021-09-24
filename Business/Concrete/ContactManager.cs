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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public IDataResult<object> Add(Contact contact)
        {
            var validationResult = ValidationTool.Validate(new ContactValidator(), contact);
            if (validationResult is not null)
            {
                return new ErrorDataResult<object>(validationResult);
            }
            _contactDal.Add(contact);
            return new SuccessDataResult<object>(Messages.Added);
        }

        public IResult Delete(Contact contact)
        {
            var businessRules = BusinessRules.Run(CheckIfContactId(contact.ContactId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _contactDal.Delete(contact);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            var result = _contactDal.GetAll();
            return new SuccessDataResult<List<Contact>>(result);
        }

        public IDataResult<Contact> GetById(int id)
        {
            var result = _contactDal.Get(x => x.ContactId == id);
            if (result is not null)
            {
                return new SuccessDataResult<Contact>(result);
            }
            return new ErrorDataResult<Contact>(Messages.NotFound);
        }

        public IResult Update(Contact contact)
        {
            _contactDal.Update(contact);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfContactId(int contactId)
        {
            var result = _contactDal.Get(x => x.ContactId == contactId);
            if (result is null)
            {
                return new ErrorResult(Messages.ContactNotFound);
            }
            return null;
        }
    }
}

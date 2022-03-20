using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.UnitOfWorks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IUnitOfWork _unitOfWork;

        public ContactManager(IContactDal contactDal, IUnitOfWork unitOfWork)
        {
            _contactDal = contactDal;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<object>> AddAsync(Contact contact)
        {
            await ValidationTool.ValidateAsync(new ContactValidator(), contact);

            await _contactDal.AddAsync(contact);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<object>(Messages.Added);
        }

        public async Task<IResult> DeleteAsync(Contact contact)
        {
            var businessRules = BusinessRules.Run(CheckIfContactId(contact.ContactId));
            if (businessRules is not null)
            {
                return businessRules;
            }
            _contactDal.Delete(contact);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<Contact>>> GetAllAsync()
        {
            var result = await _contactDal.GetAllAsync();
            return new SuccessDataResult<List<Contact>>(result);
        }

        public async Task<IDataResult<Contact>> GetByIdAsync(int id)
        {
            var result = await _contactDal.GetAsync(x => x.ContactId == id);
            if (result is not null)
            {
                return new SuccessDataResult<Contact>(result);
            }
            return new ErrorDataResult<Contact>(Messages.NotFound);
        }

        public async Task<IResult> UpdateAsync(Contact contact)
        {
            _contactDal.Update(contact);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfContactId(int contactId)
        {
            var result = _contactDal.GetAsync(x => x.ContactId == contactId).Result;
            if (result is null)
            {
                return new ErrorResult(Messages.ContactNotFound);
            }
            return null;
        }
    }
}

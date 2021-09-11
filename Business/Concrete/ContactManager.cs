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
    public class ContactManager : IContactService
    {
         IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Contact contact)
        {
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
            var result = _contactDal.Get(x => x.Id == id);
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
    }
}

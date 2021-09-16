﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<object> Add(Contact contact);
        IResult Delete(Contact contact);
        IResult Update(Contact contact);
        IDataResult<Contact> GetById(int id);
        IDataResult<List<Contact>> GetAll();
    }
}

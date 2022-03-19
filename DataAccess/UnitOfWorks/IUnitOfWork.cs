using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAboutDal Abouts { get; }
        IAdminDal Admins { get; }
        IBlogDal Blogs { get; }
        ICategoryDal Categories { get; }
        ICommentDal Comments { get; }
        IContactDal Contacts { get; }
        IMessageDal Messages { get; }
        INatificationDal Natifications { get; }
        INewsLetterDal NewsLetters { get; }
        IRoleDal Roles { get; }
        IWriterDal Writers { get; }

        Task CommitAsync();
        void Commit();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Migrations;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }

        private IAboutDal _aboutDal { get; }
        private IAdminDal _adminDal { get; }
        private IBlogDal _blogDal { get; }
        private ICategoryDal _categoryDal { get; }
        private ICommentDal _commentDal { get; }
        private IContactDal _contactDal { get; }
        private IMessageDal _messageDal { get; }
        private INatificationDal _natificationDal { get; }
        private INewsLetterDal _newsLetterDal { get; }
        private IRoleDal _roleDal { get; }
        private IWriterDal _writerDal { get; }
        
        public IAboutDal Abouts => _aboutDal ?? new EfAboutDal(_context);
        public IAdminDal Admins => _adminDal ?? new EfAdminDal(_context);
        public IBlogDal Blogs => _blogDal ?? new EfBlogDal(_context);
        public ICategoryDal Categories => _categoryDal ?? new EfCategoryDal(_context);
        public ICommentDal Comments => _commentDal ?? new EfCommentDal(_context);
        public IContactDal Contacts => _contactDal ?? new EfContactDal(_context);
        public IMessageDal Messages => _messageDal ?? new EfMessageDal(_context);
        public INatificationDal Natifications => _natificationDal ?? new EfNatificationDal(_context);
        public INewsLetterDal NewsLetters => _newsLetterDal ?? new EfNewsLetterDal(_context);
        public IRoleDal Roles => _roleDal ?? new EfRoleDal(_context);
        public IWriterDal Writers => _writerDal ?? new EfWriterDal(_context);


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

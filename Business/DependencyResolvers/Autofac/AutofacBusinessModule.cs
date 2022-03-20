using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using DataAccess.UnitOfWorks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>().SingleInstance();
            builder.RegisterType<EfNewsLetterDal>().As<INewsLetterDal>().SingleInstance();
            builder.RegisterType<EfNatificationDal>().As<INatificationDal>().SingleInstance();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().SingleInstance();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();

            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();
            builder.RegisterType<NewsLetterManager>().As<INewsLetterService>().SingleInstance();
            builder.RegisterType<NatificationManager>().As<INatificationService>().SingleInstance();
            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<AdminManager>().As<IAdminService>().SingleInstance();
            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            //builder.RegisterType<BlogContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfEntityRepositoryBase<>)).As(typeof(IEntityRepository<>));

        }
    }
}

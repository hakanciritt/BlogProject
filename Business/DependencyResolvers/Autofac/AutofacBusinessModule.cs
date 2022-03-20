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
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfContactDal>().As<IContactDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfNewsLetterDal>().As<INewsLetterDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfNatificationDal>().As<INatificationDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().InstancePerLifetimeScope();

            builder.RegisterType<AboutManager>().As<IAboutService>().InstancePerLifetimeScope();
            builder.RegisterType<BlogManager>().As<IBlogService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<CommentManager>().As<ICommentService>().InstancePerLifetimeScope();
            builder.RegisterType<ContactManager>().As<IContactService>().InstancePerLifetimeScope();
            builder.RegisterType<WriterManager>().As<IWriterService>().InstancePerLifetimeScope();
            builder.RegisterType<NewsLetterManager>().As<INewsLetterService>().InstancePerLifetimeScope();
            builder.RegisterType<NatificationManager>().As<INatificationService>().InstancePerLifetimeScope();
            builder.RegisterType<MessageManager>().As<IMessageService>().InstancePerLifetimeScope();
            builder.RegisterType<AdminManager>().As<IAdminService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleManager>().As<IRoleService>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            //builder.RegisterType<BlogContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfEntityRepositoryBase<>)).As(typeof(IEntityRepository<>));

            //builder.RegisterAssemblyTypes(typeof(IAboutService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest();

            //builder.RegisterAssemblyTypes(typeof(IAboutDal).Assembly)
            //    .Where(t => t.Name.EndsWith("Dal"))
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(BlogContext).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}

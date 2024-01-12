using Autofac;
using DotnetBootcampProject.Core.Repositories;
using DotnetBootcampProject.Core.Services;
using DotnetBootcampProject.Core.UnitOfWorks;
using DotnetBootcampProject.Repository;
using DotnetBootcampProject.Repository.Repositories;
using DotnetBootcampProject.Repository.UnitOfWorks;
using DotnetBootcampProject.Service.Mapping;
using DotnetBootcampProject.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace DotnetBootcampProject.API.Modules
{
    public class RepoModuleService:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Generic olanlar:
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            //Generic olmayan:
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            //Repo katmanındaki herhangi bir classı typeof içine verebiliriz. Bu şekilde diğerlerini kendisi bulacaktır.
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            //Service katmanındaki herhangi bir classı typeof içine verebiliriz. Bu şekilde diğerlerini kendisi bulacaktır.
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            //InstancePerLifetimeScope => Scope 
            //InstancePerDependency => Transient
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}

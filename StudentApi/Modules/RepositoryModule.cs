using Autofac;
using UniversityData.Repositories;

namespace UniversityApi.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>()
                .As<IStudentRepository>()
                .InstancePerLifetimeScope();
        }
    }
}

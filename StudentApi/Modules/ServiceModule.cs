using Autofac;
using UniversityCore.Services;

namespace UniversityApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .InstancePerLifetimeScope();
        }
    }
}

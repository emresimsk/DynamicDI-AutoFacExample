using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace AutoFacDI.Core
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var attribute in assembly.ExportedTypes)
            {
                if (attribute.Name.EndsWith("Services") && attribute.IsClass)
                {
                    var customAttributeData = attribute.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name.Contains("LifeTime"));
                    var argument = customAttributeData!.ConstructorArguments.FirstOrDefault();
                    var lifeTime = (ServiceLifetime) argument!.Value;

                    switch (lifeTime)
                    {
                        case ServiceLifetime.Scoped:
                            builder.RegisterType(attribute).AsImplementedInterfaces().InstancePerLifetimeScope();
                            break;
                        case ServiceLifetime.Transient:
                            builder.RegisterType(attribute).AsImplementedInterfaces().InstancePerDependency();
                            break;
                        default:
                            builder.RegisterType(attribute).AsImplementedInterfaces().SingleInstance();
                            break;
                    }
                }
            }

            base.Load(builder);
        }
    }
}

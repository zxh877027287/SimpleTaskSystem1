using System.Reflection;
using Abp.Modules;

namespace SimpleTaskSystem
{
    [DependsOn(typeof(SimpleTaskSystemCoreModule))]
    public class SimpleTaskSystemApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

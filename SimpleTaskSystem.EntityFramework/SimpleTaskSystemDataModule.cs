using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using SimpleTaskSystem.EntityFramework;

namespace SimpleTaskSystem
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(SimpleTaskSystemCoreModule))]
    public class SimpleTaskSystemDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<SimpleTaskSystemDbContext>(null);
        }
    }
}

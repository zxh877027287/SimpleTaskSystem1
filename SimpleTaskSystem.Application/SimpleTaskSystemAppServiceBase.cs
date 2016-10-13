using Abp.Application.Services;

namespace SimpleTaskSystem
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SimpleTaskSystemAppServiceBase : ApplicationService
    {
        protected SimpleTaskSystemAppServiceBase()
        {
            LocalizationSourceName = SimpleTaskSystemConsts.LocalizationSourceName;
        }
    }
}
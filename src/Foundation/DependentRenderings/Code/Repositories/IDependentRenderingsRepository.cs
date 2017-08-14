using Sitecore.Data.Items;
using Sitecore.Foundation.DependentRenderings.Models;

namespace Sitecore.Foundation.DependentRenderings.Repositories
{
    public interface IDependentRenderingsRepository
    {
        RenderingArgsCollection GetComponentScripts(Item contextItem, string placeholder);
    }
}

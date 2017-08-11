using Sitecore.Data.Items;
using Sitecore.Foundation.DependentRenderings.Models;

namespace Sitecore.Foundation.DependentRenderings.Repositories
{
    public interface IComponentScriptsRepository
    {
        ComponentScriptCollection GetComponentScripts(Item contextItem, string placeholder);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Sitecore.Foundation.DependentRenderings.Repositories;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Foundation.DependentRenderings.Extensions
{
    public static class SitecoreHelperExtensions
    {
        public static HtmlString ScriptPlaceholder(this SitecoreHelper sitecoreHelper, string placeholderKey)
        {
            var repository = new ComponentScriptsRepository();
            var model = repository.GetComponentScripts(sitecoreHelper.CurrentItem, placeholderKey);
            var output = new StringBuilder();
            var outputEntries = new List<string>();
            foreach (var script in model)
            {
                var renderingHtml = sitecoreHelper.Rendering(script.RenderingId, new { datasource = script.Datasource });
                outputEntries.Add(renderingHtml.ToString());
            }
            foreach (var html in outputEntries.Distinct())
            {
                output.Append(html);
            }
            return new HtmlString(output.ToString());
        }
    }
}
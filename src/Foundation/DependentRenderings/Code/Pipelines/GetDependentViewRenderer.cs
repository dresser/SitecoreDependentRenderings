using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Foundation.DependentRenderings.Pipelines
{
    public class GetDependentViewRenderer : Sitecore.Mvc.Pipelines.Response.GetRenderer.GetViewRenderer
    {
        protected override string GetViewPath(Rendering rendering, GetRendererArgs args)
        {
            return this.GetViewPathFromRenderingType(rendering, args) ?? this.GetViewPathFromRelatedRenderingItem(rendering);
        }

        protected string GetViewPathFromRelatedRenderingItem(Rendering rendering)
        {
            RenderingItem renderingItem = rendering.RenderingItem;
            if (renderingItem == null || renderingItem.InnerItem.TemplateID != Templates.ViewRenderingWithDependency.ID)
                return (string)null;
            string str = renderingItem.InnerItem["path"];
            if (str.IsWhiteSpaceOrNull())
                return (string)null;
            return str;
        }
    }
}
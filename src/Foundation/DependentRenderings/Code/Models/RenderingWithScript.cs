using System.Collections.Generic;
using Sitecore.Data;

namespace Sitecore.Foundation.DependentRenderings.Models
{
    public class RenderingWithScript
    {
        public ID ID { get; set; }
        public IList<RelatedRendering> RelatedRenderings { get; set; }
    }
}
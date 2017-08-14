using System.Collections.Generic;
using Sitecore.Data;

namespace Sitecore.Foundation.DependentRenderings.Models
{
    public class RenderingWithDependency
    {
        public ID ID { get; set; }
        public IList<DependentRendering> RelatedRenderings { get; set; }
    }
}
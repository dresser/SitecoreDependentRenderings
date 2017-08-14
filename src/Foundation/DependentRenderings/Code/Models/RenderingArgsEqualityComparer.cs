using System.Collections.Generic;

namespace Sitecore.Foundation.DependentRenderings.Models
{
    public class RenderingArgsEqualityComparer : IEqualityComparer<RenderingArgs>
    {
        public bool Equals(RenderingArgs x, RenderingArgs y)
        {
            return x.RenderingId == y.RenderingId &&
                   x.Datasource == y.Datasource;
        }

        public int GetHashCode(RenderingArgs obj)
        {
            return obj.RenderingId.GetHashCode() ^ obj.Datasource?.GetHashCode() ?? 0;
        }
    }
}
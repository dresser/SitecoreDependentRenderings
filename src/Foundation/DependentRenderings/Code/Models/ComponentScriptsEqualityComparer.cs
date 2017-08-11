using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.DependentRenderings.Models
{
    public class ComponentScriptsEqualityComparer : IEqualityComparer<ComponentScript>
    {
        public bool Equals(ComponentScript x, ComponentScript y)
        {
            return x.RenderingId == y.RenderingId &&
                   x.Datasource == y.Datasource;
        }

        public int GetHashCode(ComponentScript obj)
        {
            return obj.RenderingId.GetHashCode() ^ obj.Datasource?.GetHashCode() ?? 0;
        }
    }
}
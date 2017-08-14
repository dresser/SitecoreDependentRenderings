using System.Collections;
using System.Collections.Generic;

namespace Sitecore.Foundation.DependentRenderings.Models
{
    public class RenderingArgsCollection : IReadOnlyList<RenderingArgs>
    {
        private readonly List<RenderingArgs> _componentScripts;

        public RenderingArgsCollection(IEnumerable<RenderingArgs> collection)
        {
            _componentScripts = new List<RenderingArgs>(collection);
        }

        public RenderingArgs this[int index] => _componentScripts[index];

        public int Count => _componentScripts.Count;

        public IEnumerator<RenderingArgs> GetEnumerator()
        {
            return _componentScripts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _componentScripts.GetEnumerator();
        }
    }
}
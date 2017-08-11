using System;
using System.Collections;
using System.Collections.Generic;

namespace Sitecore.Foundation.DependentRenderings.Models
{
    public class ComponentScriptCollection : IReadOnlyList<ComponentScript>
    {
        private readonly List<ComponentScript> _componentScripts;

        public ComponentScriptCollection(IEnumerable<ComponentScript> collection)
        {
            _componentScripts = new List<ComponentScript>(collection);
        }

        public ComponentScript this[int index] => _componentScripts[index];

        public int Count => _componentScripts.Count;

        public IEnumerator<ComponentScript> GetEnumerator()
        {
            return _componentScripts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _componentScripts.GetEnumerator();
        }
    }
}
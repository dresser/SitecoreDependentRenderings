using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Layouts;

namespace Sitecore.Foundation.DependentRenderings.Extensions
{
    public static class ItemExtensions
    {
        public static LayoutDefinition GetFinalLayoutDefinition(this Item item)
        {
            var layoutField = item.Fields[FieldIDs.FinalLayoutField];
            var fieldValue = LayoutField.GetFieldValue(layoutField);
            if (string.IsNullOrEmpty(fieldValue))
                return null;

            return LayoutDefinition.Parse(fieldValue);
        }

        public static IEnumerable<RenderingDefinition> GetFinalLayoutRenderingDefinitions(this Item item)
        {
            LayoutDefinition layout;
            if (item == null || (layout = item.GetFinalLayoutDefinition()) == null)
                return Enumerable.Empty<RenderingDefinition>();
            var devices = layout.Devices.Cast<DeviceDefinition>();
            return devices
                .SelectMany(device => device.Renderings.Cast<RenderingDefinition>())
                .ToList();
        }

        public static IEnumerable<Item> GetMultiListValueItems(this Item item, ID fieldId)
        {
            return new MultilistField(item.Fields[fieldId]).GetItems();
        }
    }
}
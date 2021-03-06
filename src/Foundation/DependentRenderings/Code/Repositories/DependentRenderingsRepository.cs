﻿using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Foundation.DependentRenderings.Extensions;
using Sitecore.Foundation.DependentRenderings.Models;

namespace Sitecore.Foundation.DependentRenderings.Repositories
{
    public class DependentRenderingsRepository : IDependentRenderingsRepository
    {
        public RenderingArgsCollection GetComponentScripts(Item contextItem, string placeholder)
        {
            var scriptDependentRenderings = GetScriptDependentRenderings(contextItem.Database);
            var contextItemRenderings = contextItem.GetFinalLayoutRenderingDefinitions();
            return new RenderingArgsCollection(contextItemRenderings.SelectMany(
                cir => scriptDependentRenderings.Where(sdr => cir.ItemID == sdr.ID.ToString())
                    .SelectMany(sdr => sdr.RelatedRenderings.Where(sri => sri.Placeholder == placeholder)),
                (renderingDef, dependentRendering) => new RenderingArgs
                {
                    Datasource = renderingDef.Datasource,
                    RenderingId = dependentRendering.ID.ToString()
                }
            ).Distinct(new RenderingArgsEqualityComparer()));
        }

        private List<RenderingWithDependency> GetScriptDependentRenderings(Database database)
        {
            var query = $"/sitecore/layout/Renderings//*[@@templateid='{Templates.ControllerRenderingWithDependency.ID}' or @@templateid='{Templates.ViewRenderingWithDependency.ID}']";
            var items = database.SelectItems(query) ?? new Item[] {};
            return items.Select(i => new RenderingWithDependency
            {
                ID = i.ID,
                RelatedRenderings =
                    i.GetMultiListValueItems(Templates.BaseRenderingWithDependency.Fields.RelatedRenderings).
                        Select(
                            sri =>
                                new DependentRendering
                                {
                                    ID = sri.ID,
                                    Placeholder = sri[Templates.Rendering.Fields.Placeholder]
                                })
                        .ToList()
            }).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind2024StarterApp.Data;

namespace NorthWind2024StarterApp.Classes;
internal class EntityOperations
{
    public static List<EntityItem> ModelDetails()
    {
        List<EntityItem> entityListItems = [];


        using var context = new Context();
        var models = context.GetModelNames();

        entityListItems.AddRange(models.Select(model => new
            {
                model,
                columns = context.GetModelProperties(model.Name)
            })
            .Where(mc => mc.columns.Any())
            .Select(mc => new EntityItem { Name = mc.model.Name, Columns = mc.columns.ToList() }));

        return entityListItems;
    }
}

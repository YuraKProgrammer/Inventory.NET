using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public static class Converter
    {
        public static Recipe CraftingTableToRecipe(CraftingTable craftingTable)
        {
            return new Recipe(craftingTable.Ingredients,craftingTable.Result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class CraftingTable
    {
        public Cell[,] Ingredients = new Cell[3, 3];
        public Cell Result = new Cell(new Items.ItemsGroup(null,0));
    }
}

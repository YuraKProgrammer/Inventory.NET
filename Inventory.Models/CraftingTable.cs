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

        public CraftingTable()
        {
            for (var x=0; x<3; x++)
            {
                for (var y=0; y<3; y++)
                {
                    Ingredients[x, y] = new Cell(new Items.ItemsGroup(null, 0));
                }
            }
        }
    }
}

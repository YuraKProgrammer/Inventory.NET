using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public Cell[,] Ingredients = new Cell[3, 3];
        public Cell Result = new Cell(new Items.ItemsGroup(null, 0));
    }
}

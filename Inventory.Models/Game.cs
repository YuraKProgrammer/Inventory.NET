using Inventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Game
    {
        public Inventory Inventory = new Inventory(9, 5);
        public CraftingTable CraftingTable = new CraftingTable();
        public ItemsGroup TakenItemsGroup = new ItemsGroup(null,0);
        public List<Recipe> recipes = new List<Recipe>();
    }
}

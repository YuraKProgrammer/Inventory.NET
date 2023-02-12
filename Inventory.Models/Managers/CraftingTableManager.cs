using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Managers
{
    public class CraftingTableManager
    {
        public CraftingTable CheckCraft(CraftingTable ct, List<Recipe> rs) 
        {
            foreach(var r in rs)
            {
                if (Comparer.CompareIngregients(ct.Ingredients, r.Ingredients))
                {
                    ct = MakeCraft(ct, r);   
                }
            }
            return ct;
        }

        private CraftingTable MakeCraft(CraftingTable ct, Recipe r)
        {
            for (int x=0; x<3; x++)
            {
                for (int y=0; y<3; y++)
                {
                    ct.Ingredients[x, y].ItemsGroup.Item = null;
                    ct.Ingredients[x, y].ItemsGroup.Count = 0;
                }
            }
            ct.Result = r.Result;
            return ct;
        }
    }
       
}

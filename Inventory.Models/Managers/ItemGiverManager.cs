using Inventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Managers
{
    public class ItemGiverManager
    {
        public Inventory GiveItem(Inventory inv, IItem item, int maxStackSize)
        {
            for (var y=0; y<inv.ySize; y++)
            {
                for (var x=0; x<inv.xSize; x++)
                {
                    if (!CellVoidChecker.CheckCellIsNotEmpty(inv.cells[x, y]))
                    {
                        inv.cells[x, y] = new Cell(new ItemsGroup(item, 1));
                        return inv;
                    }
                    else
                    {
                        if (Comparer.CompareItems(inv.cells[x, y].ItemsGroup.Item,item) && inv.cells[x,y].ItemsGroup.Count+1<=maxStackSize)
                        {
                            inv.Add1Item(x, y);
                            return inv;
                        }
                    }
                }
            }    
            return inv;
        }

        public CraftingTable GiveItemCT(CraftingTable ct, IItem item, int maxStackSize)
        {
            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                {
                    if (!CellVoidChecker.CheckCellIsNotEmpty(ct.Ingredients[x, y]))
                    {
                        ct.Ingredients[x, y] = new Cell(new ItemsGroup(item, 1));
                        return ct;
                    }
                    else
                    {
                        if (Comparer.CompareItems(ct.Ingredients[x, y].ItemsGroup.Item, item) && ct.Ingredients[x, y].ItemsGroup.Count + 1 <= maxStackSize)
                        {
                            ct.Ingredients[x, y].ItemsGroup.Count++;
                            return ct;
                        }
                    }
                }
            }
            return ct;
        }
    }
}

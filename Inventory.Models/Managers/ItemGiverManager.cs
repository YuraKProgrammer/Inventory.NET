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
        public Inventory GiveItem(Inventory inv, IItem item)
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
                        if (inv.cells[x, y].ItemsGroup.Item == item)
                        {
                            inv.Add1Item(x, y);
                            return inv;
                        }
                    }
                }
            }    
            return inv;
        }
    }
}

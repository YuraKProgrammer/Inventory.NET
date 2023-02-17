using Inventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public static class CellVoidChecker
    {
        public static bool CheckCellIsNotEmpty(Cell cell)
        {
            if (cell != null && cell.ItemsGroup != null && cell.ItemsGroup.Item != null && cell.ItemsGroup.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckItemsGroupIsNotEmpty(ItemsGroup itemsGroup)
        {
            return CheckCellIsNotEmpty(new Cell(itemsGroup));
        }
    }
}

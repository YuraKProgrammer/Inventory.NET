using Inventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    [Serializable]
    public class Cell
    {
        public ItemsGroup ItemsGroup { get; set; }

        public Cell(ItemsGroup itemsGroup)
        {
            ItemsGroup = itemsGroup;
        }
    }
}

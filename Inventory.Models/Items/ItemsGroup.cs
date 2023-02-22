using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    [Serializable]
    public class ItemsGroup
    {
        public IItem Item { get; set; }
        public int Count { get; set; }

        public ItemsGroup(IItem item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}

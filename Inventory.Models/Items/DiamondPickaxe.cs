using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    [Serializable]
    public class DiamondPickaxe : IItem
    {
        public string Image { get; }

        public DiamondPickaxe()
        {
            Image = @"/Inventory.DesktopClient;component/images/diamondpickaxe.png";
        }
    }
}

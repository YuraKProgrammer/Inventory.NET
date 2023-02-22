using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    [Serializable]
    public class WoodSword : IItem
    {
        public string Image { get; set; }

        public WoodSword()
        {
            Image = @"/Inventory.DesktopClient;component/images/woodsword.png";
        }
    }
}

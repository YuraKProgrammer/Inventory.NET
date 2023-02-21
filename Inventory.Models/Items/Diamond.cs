using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    public class Diamond : IItem
    {
        public string Image { get; }

        public Diamond()
        {
            Image = @"/Inventory.DesktopClient;component/images/diamond.png";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    public class Stick : IItem
    {
        public string Image { get; set; }

        public Stick()
        {
            Image = @"/Inventory.DesktopClient;component/images/stick.png";
        }
    }
}

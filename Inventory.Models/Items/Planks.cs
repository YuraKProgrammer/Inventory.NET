using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    public class Planks : IItem
    {
        public string Image { get; }

        public Planks()
        {
            Image = @"/Inventory.DesktopClient;component/images/planks.png";
        }
    }
}

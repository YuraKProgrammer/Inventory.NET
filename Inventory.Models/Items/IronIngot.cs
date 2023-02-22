using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Items
{
    [Serializable]
    public class IronIngot : IItem
    {
        public string Image { get; }

        public IronIngot()
        {
            Image = @"/Inventory.DesktopClient;component/images/ironingot.png";
        }
    }
}

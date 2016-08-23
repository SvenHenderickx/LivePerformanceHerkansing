using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class WinkelOrde
    {
        public Product Product { get; set; }
        public int volgRoute { get; set; }

        public WinkelOrde(Product product, int volgRoute)
        {
            Product = product;
            this.volgRoute = volgRoute;
        }
    }
}

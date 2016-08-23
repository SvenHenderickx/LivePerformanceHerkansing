using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class WinkelOrde : IComparable<WinkelOrde>
    {
        public Product Product { get; set; }
        public int VolgRoute { get; set; }

        public WinkelOrde(Product product, int volgRoute)
        {
            Product = product;
            this.VolgRoute = volgRoute;
        }

        public int CompareTo(WinkelOrde other)
        {
            if (this.VolgRoute > other.VolgRoute)
            {
                return 1;
            }
            else if (this.VolgRoute < other.VolgRoute)
            {
                return -1;
            }
            return 0;
        }
    }
}

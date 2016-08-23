using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class ZuinigeGerechten : IComparable<ZuinigeGerechten>
    {
        /// <summary>
        /// Moet 4 zijn
        /// </summary>
        public List<Gerecht> Gerechten { get; set; }
        public int Vermindering { get; set; }

        public ZuinigeGerechten()
        {
            Gerechten = new List<Gerecht>();
        }

        public ZuinigeGerechten(List<Gerecht> gerechten)
        {
            Gerechten = gerechten;
        }

        public override string ToString()
        {
            string alleGerechten = "";
            foreach (Gerecht g in Gerechten)
            {
                alleGerechten += g.Naam + " - ";
            }
            alleGerechten = alleGerechten + " " + Vermindering.ToString();
            return alleGerechten;
        }

        /// <summary>
        /// Sorteren op meest zuinig
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ZuinigeGerechten other)
        {
            if (this.Vermindering > other.Vermindering)
            {
                return -1;
            }
            else if (this.Vermindering < other.Vermindering)
            {
                return 1;
            }
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class ZuinigeGerechten
    {
        /// <summary>
        /// Moet 4 zijn
        /// </summary>
        public List<Gerecht> Gerechten { get; set; }

        public int AfvalPerGerecht { get; set; }
        public int AfvalSamen { get; set; }
        public int Vermindering { get; set; }

        public ZuinigeGerechten()
        {
            Gerechten = new List<Gerecht>();
        }

        public ZuinigeGerechten(List<Gerecht> gerechten, int afvalPerGerecht, int afvalSamen, int vermindering)
        {
            Gerechten = gerechten;
            AfvalPerGerecht = afvalPerGerecht;
            AfvalSamen = afvalSamen;
            Vermindering = vermindering;
        }

        public bool GerechtToevoegen(Gerecht gerecht)
        {
            if (Gerechten.Count > 4)
            {
                return false;
            }
            foreach (Gerecht g in Gerechten)
            {
                if (g.Id == gerecht.Id)
                {
                    return false;
                }
            }
            Gerechten.Add(gerecht);
            return true;
        }

        public override string ToString()
        {
            string alleGerechten = "";
            foreach (Gerecht g in Gerechten)
            {
                alleGerechten += g.Naam + " ";
            }
            return alleGerechten;
        }
    }
}

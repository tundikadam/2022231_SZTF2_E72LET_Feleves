using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Prioritas
    {
        public ITeendo fej;

        public void PrioritasiSorBeszuras(ITeendo teendo)
        {
            if (fej == null)
            {
                fej = teendo;
                return;
            }

            if (fej.Prioritas < teendo.Prioritas)
            {
                teendo.Kovetkezo = fej;
                fej = teendo;
                return;
            }

            ITeendo a = fej;
            while (a.Kovetkezo != null && a.Kovetkezo.Prioritas > teendo.Prioritas)
            {
                a = a.Kovetkezo;
            }
            teendo.Kovetkezo = a.Kovetkezo;
            a.Kovetkezo = teendo;
        }

        public void Bejaras()
        {
            ITeendo p = fej;
            while (p != null)
            {
                p = p.Kovetkezo;
            }
        }
        public Prioritas()
        {
            this.fej = null;
        }
    }
}

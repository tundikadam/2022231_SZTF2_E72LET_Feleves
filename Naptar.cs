using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Naptar
    {
        public Nap fej;

        public void NapBeszuras(Nap nap)
        {
            if (fej == null)
            {
                fej = nap;
                return;
            }

            if (fej.datum > nap.datum)
            {
                nap.Kovetkezo = fej;
                fej = nap;
                return;
            }

            Nap a = fej;
            while (a.Kovetkezo != null && a.Kovetkezo.datum < nap.datum)
            {
                a = a.Kovetkezo;
            }
            nap.Kovetkezo = a.Kovetkezo;
            a.Kovetkezo = nap;
        }

        public Naptar()
        {
            this.fej = null;
        }
    }
}

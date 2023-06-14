using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class KifutottunkAzIdobolException:Exception
    {
        public KifutottunkAzIdobolException(Egyszeri egyszeri) : base("A(z) " + egyszeri.nev + " feladat határidejelejárt! \n Új határidő megadása:")
        {

        }
    }
}

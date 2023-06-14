using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal interface ITeendo
    {
        int Idotartam { get; }
        int Prioritas { get; }
        ITeendo Kovetkezo { get; set; }
    }
}

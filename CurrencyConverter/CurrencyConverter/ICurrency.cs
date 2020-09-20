using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    interface ICurrency
    {
        char Symbol { get; set; }
        double ValueAgainstPound { get; set; }
        string Name { get; set; }
        
    }
}

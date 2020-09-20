using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    interface IParser
    {
        bool InitialiseCurrencies(out List<Currency> currencies);

        bool InitialiseCurrencies(string filePath, out List<Currency> currencies);

        bool IsCurrencyDataValid(string filePath);
    }
}

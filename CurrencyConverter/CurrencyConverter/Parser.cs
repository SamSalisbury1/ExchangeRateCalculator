using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CurrencyConverter
{
    public class Parser : IParser
    {
        public bool InitialiseCurrencies(out List<Currency> currencies)
        {
            string filePath = "CurrencyData.txt";
            bool threwError = InitialiseCurrencies(filePath, out List<Currency> currencyList);

            currencies = currencyList;

            return threwError;
        }

        public bool InitialiseCurrencies(string filePath, out List<Currency> currencies)
        {
            currencies = new List<Currency>();

            if (!IsCurrencyDataValid(filePath))
            {
                return false;
            }

            string[] fileLines = File.ReadAllLines(filePath);
            foreach (string line in fileLines)
            {
                Currency currentCurrency = new Currency();
                string[] lineComponents = line.Split('-');

                if (lineComponents.Length != 3 || !double.TryParse(lineComponents[2], out double valueAgainstPound))
                {
                    return false;
                }

                currentCurrency.Symbol = Convert.ToChar(lineComponents[0]); ;
                currentCurrency.Name = lineComponents[1]; ;
                currentCurrency.ValueAgainstPound = double.Parse(lineComponents[2]);

                currencies.Add(currentCurrency);
            }

            return true;
        }

        public bool IsCurrencyDataValid(string filePath)
        {
            if (filePath == "" || !File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}

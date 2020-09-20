using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrencyConverter
{
    interface ILogBuilder
    {
        void CreateNewLog(double pounds, double convertedCurrencyValue, Currency currency);

        void CreateNewLog(double pounds, double convertedCurrencyValue, Currency currency, string filePath);

        XDocument GetAuditLog(string filePath);
    }
}

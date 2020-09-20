using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace CurrencyConverter
{
    public class LogBuilder : ILogBuilder
    {
        public void CreateNewLog(double pounds, double convertedCurrencyValue, Currency currency)
        {
            string filePath = "AuditLog.xml";
            CreateNewLog(pounds, convertedCurrencyValue, currency, filePath);
        }

        public void CreateNewLog(double pounds, double convertedCurrencyValue, Currency currency, string filePath)
        {
            DateTime timeOfRequest = DateTime.Now;

            if (!File.Exists(filePath))
            {
                XmlWriter writer = XmlWriter.Create(filePath);
                writer.WriteStartElement("Conversions");
                writer.WriteEndElement();
                writer.Close();
            }
            XElement element = XElement.Load(filePath);
            element.Add(new XElement("Conversion",
                new XAttribute("DateTime", timeOfRequest.ToString()),
                new XAttribute("Amount", "£" + pounds.ToString()),
                new XAttribute("Currency", currency.Name),
                new XAttribute("ExchangedAmount", currency.Symbol + convertedCurrencyValue.ToString())));

            element.Save(filePath);
        }

        public XDocument GetAuditLog(string filePath)
        {
            if (filePath != "" && File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                return XDocument.Load(filePath);
            }

            return null;
        }
    }
}

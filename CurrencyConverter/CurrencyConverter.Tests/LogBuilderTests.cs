using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrencyConverter.Tests
{
    class LogBuilderTests
    {
        [Test]
        public void Increase_Size_Of_Audit_Log_When_Adding_New_Value()
        {
            LogBuilder logBuilder = new LogBuilder();
            XDocument documentBeforeChange = logBuilder.GetAuditLog("TestAuditLog.xml");
            Currency curr = new Currency
            {
                Symbol = '$',
                Name = "USD",
                ValueAgainstPound = 1.22
            };

            logBuilder.CreateNewLog(1.00, 1.22, curr, "TestAuditLog.xml");
            XDocument documentAfterChange = logBuilder.GetAuditLog("TestAuditLog.xml");
            Assert.Greater(documentAfterChange.Descendants("Conversion").ToList().Count, documentBeforeChange.Descendants("Conversion").ToList().Count);
        }

        [Test]
        public void Return_Null_If_File_Does_Not_Exist()
        {
            LogBuilder logBuilder = new LogBuilder();

            Assert.IsNull(logBuilder.GetAuditLog(""));
        }

        [Test]
        public void Return_Null_If_File_Is_Empty()
        {
            LogBuilder logBuilder = new LogBuilder();

            Assert.IsNull(logBuilder.GetAuditLog("EmptyXml.xml"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CurrencyConverter.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void Give_IsCurrencyDataValid_Empty_File_Path()
        {
            Parser parser = new Parser();

            Assert.IsFalse(parser.IsCurrencyDataValid(""));
        }

        [Test]
        public void Give_IsCurrencyData_Empty_File()
        {
            Parser parser = new Parser();

            Assert.IsFalse(parser.IsCurrencyDataValid("EmptyFileTest.txt"));
        }

        [Test]
        public void Give_IsCurrencyData_Incorrectly_File_That_Does_Not_Exist()
        {
            Parser parser = new Parser();

            Assert.IsFalse(parser.IsCurrencyDataValid("blablabla.txt"));
        }

        [Test]
        public void Give_InitialiseCurrencies_Badly_Formatted_File()
        {
            Parser parser = new Parser();

            Assert.IsFalse(parser.IsCurrencyDataValid("InvalidLayoutTest.txt"));
        }

        [Test]
        public void Give_InitialiseCurrencies_Format_With_To_Few_Arguments()
        {
            Parser parser = new Parser();

            Assert.IsFalse(parser.IsCurrencyDataValid("TooFewArguments.txt"));
        }
    }
}

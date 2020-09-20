using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency : ICurrency
    {
        private char symbol;
        private double valueAgainstPound;
        private string name;

        public char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public double ValueAgainstPound
        {
            get { return valueAgainstPound; }
            set { valueAgainstPound = value;}
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainObjects.Flight
{
    public class FlightCurrency
    {
        public string Code { get; set; }

        public char Symbol { get; set; }

        public char ThousandsSeparator { get; set; }

        public char DecimalSeparator { get; set; }

        public bool SymbolOnLeft { get; set; }

        public bool SpaceBetweenAmountAndSymbol { get; set; }

        public int RoundingCoefficient { get; set; }

        public int DecimalDigits { get; set; }
    }
}

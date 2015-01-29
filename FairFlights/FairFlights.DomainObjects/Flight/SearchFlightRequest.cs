using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainObjects.Flight
{
    public class SearchFlightRequest
    {
        public string ApiKey { get; set; }

        public string Market { get; set; }

        public string Currency { get; set; }

        public string Locale { get; set; }

        public string OriginPlace { get; set; }

        public string DestinationPlace { get; set; }

        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        public string OutboundPartialDate { get; set; }

        /// <summary>
        /// Gets or sets the return date.
        /// </summary>
        public string InboundPartialDate { get; set; }
    }
}

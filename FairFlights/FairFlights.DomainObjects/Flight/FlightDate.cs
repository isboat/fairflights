using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainObjects.Flight
{
    using Newtonsoft.Json;

    public class FlightDates
    {
        [JsonProperty("OutboundDates")]
        public List<FlightDate> OutboundDates { get; set; }

        [JsonProperty("InboundDates")]
        public List<FlightDate> InboundDates { get; set; }
    }

    public class FlightDate
    {
        [JsonProperty("PartialDate")]
        public DateTime PartialDate { get; set; }

        [JsonProperty("QuoteIds")]
        public List<int> QouteIds { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }
    }
}

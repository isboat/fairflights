using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainObjects.Flight
{
    using Newtonsoft.Json;

    public class FlightDate
    {
        [JsonProperty("PartialDate")]
        public DateTime PartialDate { get; set; }

        [JsonProperty("QuotesIds")]
        public List<int> QouteIds { get; set; }

        [JsonProperty("Price")]
        public int Price { get; set; }
    }
}

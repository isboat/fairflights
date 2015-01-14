using System.Collections.Generic;

namespace FairFlights.DomainObjects.Flight
{
    using Newtonsoft.Json;

    public class SearchFlightResponse
    {
        [JsonProperty("Quotes")]
        public List<FlightQuote> FlightQuotes { get; set; }

        [JsonProperty("Places")]
        public List<FlightPlace> FlightPlaces { get; set; }

        [JsonProperty("Carriers")]
        public List<FlightCarrier> FlightCarriers { get; set; }

        [JsonProperty("Currencies")]
        public List<FlightCurrency> FlightCurrencies { get; set; }
    }
}

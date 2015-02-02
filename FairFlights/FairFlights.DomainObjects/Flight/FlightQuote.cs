namespace FairFlights.DomainObjects.Flight
{
    using Newtonsoft.Json;

    public class FlightQuote
    {
        [JsonProperty("QuoteId")]
        public int QuoteId { get; set; }

        [JsonProperty("MinPrice")]
        public decimal MinPrice { get; set; }

        [JsonProperty("Direct")]
        public bool IsDirect { get; set; }

        [JsonProperty("OutboundLeg")]
        public FlightBoundLeg OutboundLeg { get; set; }

        [JsonProperty("InboundLeg")]
        public FlightBoundLeg InboundLeg { get; set; }
    }
}

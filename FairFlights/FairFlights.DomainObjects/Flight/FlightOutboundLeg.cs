﻿using System;
using System.Collections.Generic;

namespace FairFlights.DomainObjects.Flight
{
    using Newtonsoft.Json;

    /// <summary>
    /// The flight outbound leg.
    /// </summary>
    public class FlightOutboundLeg
    {
        [JsonProperty("CarriersIds")]
        public int[] CarrierIds { get; set; }

        [JsonProperty("OriginId")]
        public int OriginId { get; set; }

        [JsonProperty("DestinationId")]
        public int DestinationId { get; set; }

        [JsonProperty("DepartureDate")]
        public DateTime DepartureDate { get; set; }
    }
}

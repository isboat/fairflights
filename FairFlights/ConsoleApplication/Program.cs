namespace ConsoleApplication
{
    using FairFlights.DomainObjects.Flight;
    using FairFlights.DomainServices;

    class Program
    {
        static void Main(string[] args)
        {
            var flightService = new FlightService();
            var response = flightService.SearchFlight(new SearchFlightRequest {
                Market = "GB",
                Currency = "GBP",
                Locale = "en-GB",
                OriginPlace = "LON",
                DestinationPlace = "EDI",
                OutboundPartialDate = "2015-01-19",
                InboundPartialDate = "2015-01-26"
            });

            var s = 0;
        }
    }
}

namespace FairFlights.DomainServices
{
    using FairFlights.Configuration;
    using FairFlights.DataConsumer;
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;
    using FairFlights.DomainServices.Interfaces;
    using FairFlights.ViewModels.Flight;

    /// <summary>
    /// The flight service.
    /// </summary>
    public class FlightService : IFlightService
    {
        /// <summary>
        /// The data consumer manager.
        /// </summary>
        private readonly DataConsumerManager dataConsumerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightService"/> class.
        /// </summary>
        public FlightService()
        {
            var dataSupplier = IoC.GetInstance.Resolve<IDataSupplier>();
            this.dataConsumerManager = new DataConsumerManager(dataSupplier);
        }

        /// <summary>
        /// The search flight.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SearchFlightResponse"/>.
        /// </returns>
        public SearchResponseViewModel SearchFlight(SearchRequestViewModel request)
        {
            var req = new SearchFlightRequest
                          {
                              ApiKey = AppSettings.SkyScannerApiKey,
                              Currency = "GBP",
                              Market = "GB",
                              Locale = "en-GB",
                              OriginPlace = request.Departure,
                              OutboundPartialDate = request.DepartureDate.ToString("dd/mm/yyyy"),
                              DestinationPlace = request.Arrival,
                              InboundPartialDate = request.IsReturn ? request.ArrivalDate.ToString("dd/mm/yyyy") : string.Empty
                          };

            //var data = this.dataConsumerManager.SearchFlight(req);

            var response = new SearchResponseViewModel();

            //if (data != null)
            //{
            //    // fill response;
            //}

            return response;
        }
    }
}

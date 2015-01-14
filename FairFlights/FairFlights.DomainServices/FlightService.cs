namespace FairFlights.DomainServices
{
    using FairFlights.Configuration;
    using FairFlights.DataConsumer;
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;
    using FairFlights.DomainServices.Interfaces;

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
        public SearchFlightResponse SearchFlight(SearchFlightRequest request)
        {
            return this.dataConsumerManager.SearchFlight(request);
        }
    }
}

namespace FairFlights.DomainServices.Interfaces
{
    using FairFlights.DomainObjects.Flight;

    /// <summary>
    /// The FlightService interface.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// The search flight.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SearchFlightResponse"/>.
        /// </returns>
        SearchFlightResponse SearchFlight(SearchFlightRequest request);
    }
}

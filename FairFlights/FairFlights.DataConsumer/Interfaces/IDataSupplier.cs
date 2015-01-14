namespace FairFlights.DataConsumer.Interfaces
{
    using FairFlights.DomainObjects.Flight;

    public interface IDataSupplier
    {
        SearchFlightResponse SearchFlight(SearchFlightRequest request);
        SearchResponse SearchWegoFlight(SearchRequest request);
    }
}

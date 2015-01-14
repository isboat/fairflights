namespace FairFlights.DataConsumer
{
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;

    public class DataConsumerManager
    {
        private readonly IDataSupplier dataSupplier;

        public DataConsumerManager(IDataSupplier dataSupplier)
        {
            this.dataSupplier = dataSupplier;
        }

        public SearchFlightResponse SearchFlight(SearchFlightRequest request)
        {
            return this.dataSupplier.SearchFlight(request);
        }

        public void SearchWegoFlight()
        {
            var response = dataSupplier.SearchWegoFlight(new SearchRequest { 
                ArrivalCode = "LON", 
                DepartureCode = "SYD", 
                OutboundDate = "2014-01-24", 
                InboundDate = "2014-01-29" });
        }
    }
}

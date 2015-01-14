using System.Web.Http;

namespace FairFlights.Web.Controllers
{
    using FairFlights.DomainServices.Interfaces;

    public class FlightController : ApiController
    {
        #region Private variables

        private readonly IFlightService flightService;

        #endregion

        #region Constructors

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }
        #endregion

        public string SearchFlight()
        {
            return "some string";
        }
    }
}

using System.Web.Http;

namespace FairFlights.Web.Controllers
{
    using System.Net;

    using FairFlights.Configuration;
    using FairFlights.DomainServices.Interfaces;
    using FairFlights.ViewModels.Flight;

    // http://partners.api.skyscanner.net/apiservices/browsedates/v1.0/GB/GBP/en-GB/LON/JFK/2015-02-03/2015-02-05?apiKey=prtl6749387986743898559646983194

    public class FlightController : ApiController
    {
        #region Private variables

        private readonly IFlightService flightService;

        #endregion

        #region Constructors

        public FlightController()
        {
            this.flightService = IoC.GetInstance.Resolve<IFlightService>();
        }
        #endregion

        [HttpPost]
        public SearchResponseViewModel SearchFlight(SearchRequestViewModel viewModel)
        {
            if (viewModel != null)
            {
                return this.flightService.SearchFlight(viewModel);
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public string Search()
        {
            return "some string";
        }
    }
}

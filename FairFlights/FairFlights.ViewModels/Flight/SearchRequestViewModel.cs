using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    /// <summary>
    /// The search request view model.
    /// </summary>
    public class SearchRequestViewModel
    {
        public string Arrival { get; set; }

        public DateTime ArrivalDate { get; set; }

        public bool IsReturn { get; set; }

        public string Departure { get; set; }

        public DateTime DepartureDate { get; set; }

        public string CabinClass { get; set; }
    }
}

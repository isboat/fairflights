using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainObjects.Flight
{
    public class SearchRequest
    {
        public string DepartureCode { get; set; }

        public string ArrivalCode { get; set; }

        public string OutboundDate { get; set; }

        public string InboundDate { get; set; }

        public string AdultsCount { get; set; }

        public string ChildrenCount { get; set; }

        public string Cabin { get; set; }

        public string UserCountryCode { get; set; }

        public string CountrySiteCode { get; set; }
    }
}

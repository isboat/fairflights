using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainObjects.Flight
{
    public class FlightPlace
    {
        public int PlaceId { get; set; }

        public string IATACode { get; set; }

        public string Name { get; set; }

        public FlightType Type { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }
    }
}

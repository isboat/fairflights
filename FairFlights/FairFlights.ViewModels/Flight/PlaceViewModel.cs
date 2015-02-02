using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    public class PlaceViewModel
    {
        public string Name { get; set; }

        public int PlaceId { get; set; }

        public string IataCode { get; set; }

        public string PlaceType { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }
    }
}

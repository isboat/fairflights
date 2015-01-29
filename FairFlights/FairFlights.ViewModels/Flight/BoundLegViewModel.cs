using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    public class BoundLegViewModel
    {
        public int[] CarrierIds { get; set; }

        public int OriginId { get; set; }

        public int DestinationId { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}

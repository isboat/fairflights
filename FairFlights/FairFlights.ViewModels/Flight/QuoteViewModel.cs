using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    public class QuoteViewModel
    {
        public int QuoteId { get; set; }

        public decimal MinPrice { get; set; }

        public bool IsDirect { get; set; }

        public BoundLegViewModel OutboundLeg { get; set; }

        public BoundLegViewModel InboundLeg { get; set; }
    }
}

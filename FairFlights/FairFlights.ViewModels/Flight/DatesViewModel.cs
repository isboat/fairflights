using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    public class DatesViewModel
    {
        public List<DateViewModel> OutboundDates { get; set; }

        public List<DateViewModel> InboundDates { get; set; }
    }

    public class DateViewModel
    {
        public DateTime PartialDate { get; set; }

        public List<int> QouteIds { get; set; }

        public decimal Price { get; set; }
    }
}

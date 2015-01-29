using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    public class SearchResponseViewModel
    {
        public List<PlaceViewModel> Places { get; set; }

        public List<CurrencyViewModel> Currencies { get; set; }

        public List<CarriersViewModel> Carriers { get; set; }

        public List<DateViewModel> Dates { get; set; }

        public List<QuoteViewModel> Quotes { get; set; }
    }
}

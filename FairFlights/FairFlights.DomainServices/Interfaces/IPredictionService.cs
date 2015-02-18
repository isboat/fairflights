using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.DomainServices.Interfaces
{
    using FairFlights.ViewModels.Flight;

    public interface IPredictionService
    {
        void PredictPrice(SearchRequestViewModel searchRequest);
    }
}

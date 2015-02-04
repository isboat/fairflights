using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.ViewModels.Flight
{
    /// <summary>
    /// The date range.
    /// </summary>
    public enum DateRange
    {
        LastYear = 1,
        LastSixMonths = 2,
        LastThreeMonths = 3,
        LastMonth = 4,
        CustomDateRange = 5
    }
}

namespace FairFlights.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FairFlights.Configuration;
    using FairFlights.DataConsumer;
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;
    using FairFlights.DomainServices.Interfaces;
    using FairFlights.ViewModels.Flight;

    /// <summary>
    /// The flight service.
    /// </summary>
    public class FlightService : IFlightService
    {
        /// <summary>
        /// The data consumer manager.
        /// </summary>
        private readonly DataConsumerManager dataConsumerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightService"/> class.
        /// </summary>
        public FlightService()
        {
            var dataSupplier = IoC.GetInstance.Resolve<IDataSupplier>();
            this.dataConsumerManager = new DataConsumerManager(dataSupplier);
        }

        /// <summary>
        /// The search flight.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SearchFlightResponse"/>.
        /// </returns>
        public SearchResponseViewModel SearchFlight(SearchRequestViewModel request)
        {
            var req = new SearchFlightRequest
                          {
                              ApiKey = AppSettings.SkyScannerApiKey,
                              Currency = "GBP",
                              Market = "GB",
                              Locale = "en-GB",
                              OriginPlace = request.Departure,
                              OutboundPartialDate = request.DateRange == DateRange.CustomDateRange ? request.DepartureDate.ToString("yyyy-MM-dd") : this.DateRangeToString(request.DateRange),
                              DestinationPlace = request.Arrival
                          };

            if (request.IsReturn)
            {
                req.InboundPartialDate = request.DateRange == DateRange.CustomDateRange
                                             ? request.ArrivalDate.ToString("yyyy-MM-dd")
                                             : DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }

            var data = this.dataConsumerManager.SearchFlight(req);

            var response = new SearchResponseViewModel
                               {
                                   Carriers = new List<CarriersViewModel>(),
                                   Currencies = new List<CurrencyViewModel>(),
                                   Dates = new DatesViewModel { InboundDates = new List<DateViewModel>(), OutboundDates = new List<DateViewModel>()},
                                   Places = new List<PlaceViewModel>(),
                                   Quotes = new List<QuoteViewModel>()
                               };

            if (data != null)
            {
                foreach (var carrier in data.FlightCarriers)
                {
                    response.Carriers.Add(new CarriersViewModel { CarrierId = carrier.CarrierId, Name = carrier.Name});
                }

                foreach (var currency in data.FlightCurrencies)
                {
                    response.Currencies.Add(
                        new CurrencyViewModel
                            {
                                Code = currency.Code,
                                DecimalDigits = currency.DecimalDigits,
                                DecimalSeparator = currency.DecimalSeparator,
                                RoundingCoefficient = currency.RoundingCoefficient,
                                SpaceBetweenAmountAndSymbol = currency.SpaceBetweenAmountAndSymbol,
                                Symbol = currency.Symbol,
                                SymbolOnLeft = currency.SymbolOnLeft,
                                ThousandsSeparator = currency.ThousandsSeparator
                            });
                }

                foreach (var inboundDate in data.FlightDates.InboundDates)
                {
                    response.Dates.InboundDates.Add(
                        new DateViewModel
                            {
                                PartialDate = inboundDate.PartialDate,
                                Price = inboundDate.Price,
                                QouteIds = inboundDate.QouteIds
                            });
                }

                foreach (var outboundDate in data.FlightDates.OutboundDates)
                {
                    response.Dates.OutboundDates.Add(
                        new DateViewModel
                            {
                                PartialDate = outboundDate.PartialDate,
                                Price = outboundDate.Price,
                                QouteIds = outboundDate.QouteIds
                            });
                }

                foreach (var flightPlace in data.FlightPlaces)
                {
                    response.Places.Add(
                        new PlaceViewModel
                            {
                                Name = flightPlace.Name,
                                CityName = flightPlace.CityName,
                                CountryName = flightPlace.CountryName,
                                IataCode = flightPlace.IATACode,
                                PlaceId = flightPlace.PlaceId,
                                PlaceType = flightPlace.Type.ToString()
                            });
                }

                foreach (var flightQuote in data.FlightQuotes)
                {
                    var q = new QuoteViewModel
                        {
                            IsDirect = flightQuote.IsDirect,
                            MinPrice = flightQuote.MinPrice,
                            QuoteId = flightQuote.QuoteId
                        };

                    if (flightQuote.InboundLeg != null)
                    {
                        q.InboundLeg = new BoundLegViewModel 
                                    {
                                        CarrierIds = flightQuote.InboundLeg.CarrierIds,
                                        DepartureDate = flightQuote.InboundLeg.DepartureDate,
                                        DestinationId = flightQuote.InboundLeg.DestinationId,
                                        OriginId = flightQuote.InboundLeg.OriginId
                                    };
                    }

                    if (flightQuote.OutboundLeg != null)
                    {
                        q.OutboundLeg = new BoundLegViewModel
                                    {
                                        CarrierIds = flightQuote.OutboundLeg.CarrierIds,
                                        DepartureDate = flightQuote.OutboundLeg.DepartureDate,
                                        DestinationId = flightQuote.OutboundLeg.DestinationId,
                                        OriginId = flightQuote.OutboundLeg.OriginId
                                    };
                    }
                    response.Quotes.Add(q);
                }
            }

            return response;
        }

        private string DateRangeToString(DateRange range)
        {
            switch (range)
            {
                case DateRange.LastYear:
                    return DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
                case DateRange.LastSixMonths:
                    return DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd");
                case DateRange.LastThreeMonths:
                    return DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                case DateRange.LastMonth:
                    return DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                default:
                    return string.Empty;
            }
        }
    }
}

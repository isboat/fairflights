﻿namespace FairFlights.DomainServices
{
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
                              OutboundPartialDate = request.DepartureDate.ToString("yyyy-MM-d"),
                              DestinationPlace = request.Arrival,
                              InboundPartialDate = request.IsReturn ? request.ArrivalDate.ToString("yyyy-MM-d") : string.Empty
                          };

            var data = this.dataConsumerManager.SearchFlight(req);

            var response = new SearchResponseViewModel
                               {
                                   Carriers = new List<CarriersViewModel>(),
                                   Currencies = new List<CurrencyViewModel>(),
                                   Dates = new DatesViewModel(),
                                   Places = new List<PlaceViewModel>(),
                                   Quotes = new List<QuoteViewModel>()
                               };

            if (data != null)
            {
                //fill response;
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
                    response.Quotes.Add(
                        new QuoteViewModel
                            {
                                InboundLeg = new BoundLegViewModel
                                                    {
                                                        CarrierIds = flightQuote.InboundLeg.CarrierIds,
                                                        DepartureDate = flightQuote.InboundLeg.DepartureDate,
                                                        DestinationId = flightQuote.InboundLeg.DestinationId,
                                                        OriginId = flightQuote.InboundLeg.OriginId
                                                    },
                                OutboundLeg = new BoundLegViewModel
                                                  {
                                                      CarrierIds = flightQuote.OutboundLeg.CarrierIds,
                                                      DepartureDate = flightQuote.OutboundLeg.DepartureDate,
                                                      DestinationId = flightQuote.OutboundLeg.DestinationId,
                                                      OriginId = flightQuote.OutboundLeg.OriginId
                                                  },
                                IsDirect = flightQuote.IsDirect,
                                MinPrice = flightQuote.MinPrice,
                                QuoteId = flightQuote.QuoteId
                            });
                }
            }

            return response;
        }
    }
}

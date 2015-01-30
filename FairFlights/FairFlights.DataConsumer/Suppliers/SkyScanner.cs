using System;
using System.IO;
using System.Net;

namespace FairFlights.DataConsumer.Suppliers
{
    using System.Diagnostics.CodeAnalysis;

    using FairFlights.Common;
    using FairFlights.Configuration;
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;

    public class SkyScanner : IDataSupplier
    {
        public SearchFlightResponse SearchFlight(SearchFlightRequest request)
        {
            return JsonHelper.Deserialize<SearchFlightResponse>(Mock.Text);
            // required fields
            
            /*
             if (request == null || string.IsNullOrEmpty(request.Market) || string.IsNullOrEmpty(request.Currency) || 
                string.IsNullOrEmpty(request.Locale) || string.IsNullOrEmpty(request.OriginPlace) || 
                string.IsNullOrEmpty(request.DestinationPlace) || string.IsNullOrEmpty(request.OutboundPartialDate))
            {
                return null;
            }

            SearchFlightResponse response = null;

            var uri = AppSettings.SkyScannerUri;
            uri += string.Format(
                "{0}/{1}/{2}/{3}/{4}/{5}/",
                request.Market,
                request.Currency, 
                request.Locale, 
                request.OriginPlace, 
                request.DestinationPlace,
                request.OutboundPartialDate);

            if (!string.IsNullOrEmpty(request.InboundPartialDate))
            {
                uri += string.Format("{0}/", request.InboundPartialDate);
            }

            uri += string.Format("?apiKey={0}", AppSettings.SkyScannerApiKey);

            var req = WebRequest.Create(uri);
            req.ContentType = "application/json";
            try
            {
                var resp = (HttpWebResponse)req.GetResponse();
                var respStream = resp.GetResponseStream();
                if (respStream != null)
                {
                    using (var sr = new StreamReader(respStream))
                    {
                        var text = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(text))
                        {

                            //response = JsonHelper.Deserialize<SearchFlightResponse>(text);
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                throw;
            }

            return response;
            */
        }

        /*
        public QuotesResponse RequestFlightPricing(QuotesRequest request)
        {
            // Create a request using a URL that can receive a post. 
            var req = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            req.Method = "POST";

            var postData = HttpUtility.ParseQueryString(String.Empty);
            postData.Add("field1", "value1");
            postData.Add("field2", "value2");

            byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());

            // Set the ContentType property of the WebRequest.
            req.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            req.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = req.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            using (var response = req.GetResponse())
            {
                using (var responseStream = new StreamReader(response.GetResponseStream()))
                {
                    var content = responseStream.ReadToEnd();
                }
            }
            return new QuotesResponse();
        }
         */

        //public QuotesResponse RequestFlightPricing(QuotesRequest request)
        //{
        //    var req = WebRequest.Create(URI);
        //    var resp = (HttpWebResponse)req.GetResponse();
        //    string text;
        //    using (var sr = new StreamReader(resp.GetResponseStream()))
        //    {
        //        text = sr.ReadToEnd();
        //    }
        //}

        public SearchResponse SearchWegoFlight(SearchRequest request)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The mock.
    /// </summary>
    public static class Mock
    {
        public const string Text = @"<BrowseDatesResponseApiDto>
  <Currencies>
    <CurrencyDto>
      <Code>GBP</Code>
      <Symbol>£</Symbol>
      <ThousandsSeparator>,</ThousandsSeparator>
      <DecimalSeparator>.</DecimalSeparator>
      <SymbolOnLeft>true</SymbolOnLeft>
      <SpaceBetweenAmountAndSymbol>false</SpaceBetweenAmountAndSymbol>
      <RoundingCoefficient>0</RoundingCoefficient>
      <DecimalDigits>2</DecimalDigits>
    </CurrencyDto>
  </Currencies>
  <Dates>
    <OutboundDates>
      <DateDto>
        <PartialDate>2015-02-03</PartialDate>
        <QuoteIds>
          <int>2</int>
        </QuoteIds>
        <Price>337</Price>
      </DateDto>
    </OutboundDates>
    <InboundDates>
      <DateDto>
        <PartialDate>2015-02-05</PartialDate>
        <QuoteIds>
          <int>2</int>
        </QuoteIds>
        <Price>337</Price>
      </DateDto>
    </InboundDates>
  </Dates>
  <Quotes>
    <QuoteDto>
      <QuoteId>1</QuoteId>
      <MinPrice>216</MinPrice>
      <Direct>true</Direct>
      <InboundLeg>
        <CarrierIds>
          <int>1001</int>
        </CarrierIds>
        <OriginId>60987</OriginId>
        <DestinationId>65655</DestinationId>
        <DepartureDate>2015-02-05T00:00:00</DepartureDate>
      </InboundLeg>
    </QuoteDto>
    <QuoteDto>
      <QuoteId>2</QuoteId>
      <MinPrice>337</MinPrice>
      <Direct>true</Direct>
      <OutboundLeg>
        <CarrierIds>
          <int>1333</int>
        </CarrierIds>
        <OriginId>65698</OriginId>
        <DestinationId>60987</DestinationId>
        <DepartureDate>2015-02-03T00:00:00</DepartureDate>
      </OutboundLeg>
      <InboundLeg>
        <CarrierIds>
          <int>1333</int>
        </CarrierIds>
        <OriginId>60987</OriginId>
        <DestinationId>65698</DestinationId>
        <DepartureDate>2015-02-05T00:00:00</DepartureDate>
      </InboundLeg>
    </QuoteDto>
  </Quotes>
  <Places>
    <PlaceDto>
      <PlaceId>60987</PlaceId>
      <IataCode>JFK</IataCode>
      <Name>New York John F. Kennedy</Name>
      <Type>Station</Type>
      <CityName>New York</CityName>
      <CountryName>United States</CountryName>
    </PlaceDto>
    <PlaceDto>
      <PlaceId>65655</PlaceId>
      <IataCode>LGW</IataCode>
      <Name>London Gatwick</Name>
      <Type>Station</Type>
      <CityName>London</CityName>
      <CountryName>United Kingdom</CountryName>
    </PlaceDto>
    <PlaceDto>
      <PlaceId>65698</PlaceId>
      <IataCode>LHR</IataCode>
      <Name>London Heathrow</Name>
      <Type>Station</Type>
      <CityName>London</CityName>
      <CountryName>United Kingdom</CountryName>
    </PlaceDto>
  </Places>
  <Carriers>
    <CarriersDto>
      <CarrierId>1001</CarrierId>
      <Name>Norwegian</Name>
    </CarriersDto>
    <CarriersDto>
      <CarrierId>1333</CarrierId>
      <Name>Kuwait Airways</Name>
    </CarriersDto>
  </Carriers>
</BrowseDatesResponseApiDto>";
    }
}

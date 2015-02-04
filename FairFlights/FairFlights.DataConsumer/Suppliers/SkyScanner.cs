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
           // return JsonHelper.Deserialize<SearchFlightResponse>(Mock.Text);
             
            //required fields
            
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
                uri += string.Format("{0}", request.InboundPartialDate);
            }

            uri += string.Format("?apiKey={0}", AppSettings.SkyScannerApiKey);

            var req = (HttpWebRequest)WebRequest.Create(uri);
            req.ContentType = "application/json";
            try
            {
                using (var resp = (HttpWebResponse)req.GetResponse())
                {
                    var respStream = resp.GetResponseStream();
                    if (respStream != null)
                    {
                        using (var sr = new StreamReader(respStream))
                        {
                            var text = sr.ReadToEnd();
                            if (!string.IsNullOrEmpty(text))
                            {
                                response = JsonHelper.Deserialize<SearchFlightResponse>(text);
                            }
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                throw;
            }

            return response;
            
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
        public const string Text = "{'Dates':{'OutboundDates':[{'PartialDate':'2015-02-03','QuoteIds':[1,2],'Price':340.0}],'InboundDates':[{'PartialDate':'2015-02-05','QuoteIds':[2,3],'Price':340.0}]},'Quotes':[{'QuoteId':1,'MinPrice':269.0,'Direct':true,'OutboundLeg':{'CarrierIds':[1001],'OriginId':65655,'DestinationId':60987,'DepartureDate':'2015-02-03T00:00:00'}},{'QuoteId':2,'MinPrice':340.0,'Direct':true,'OutboundLeg':{'CarrierIds':[1333],'OriginId':65698,'DestinationId':60987,'DepartureDate':'2015-02-03T00:00:00'},'InboundLeg':{'CarrierIds':[1333],'OriginId':60987,'DestinationId':65698,'DepartureDate':'2015-02-05T00:00:00'}},{'QuoteId':3,'MinPrice':215.0,'Direct':true,'InboundLeg':{'CarrierIds':[1001],'OriginId':60987,'DestinationId':65655,'DepartureDate':'2015-02-05T00:00:00'}}],'Places':[{'PlaceId':60987,'IataCode':'JFK','Name':'New York John F. Kennedy','Type':'Station','CityName':'New York','CountryName':'United States'},{'PlaceId':65655,'IataCode':'LGW','Name':'London Gatwick','Type':'Station','CityName':'London','CountryName':'United Kingdom'},{'PlaceId':65698,'IataCode':'LHR','Name':'London Heathrow','Type':'Station','CityName':'London','CountryName':'United Kingdom'}],'Carriers':[{'CarrierId':1001,'Name':'Norwegian'},{'CarrierId':1333,'Name':'Kuwait Airways'}],'Currencies':[{'Code':'GBP','Symbol':'£','ThousandsSeparator':',','DecimalSeparator':'.','SymbolOnLeft':true,'SpaceBetweenAmountAndSymbol':false,'RoundingCoefficient':0,'DecimalDigits':2}]}";
    }
}

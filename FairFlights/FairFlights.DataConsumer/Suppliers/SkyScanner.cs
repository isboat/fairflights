using System;
using System.IO;
using System.Net;

namespace FairFlights.DataConsumer.Suppliers
{
    using FairFlights.Common;
    using FairFlights.Configuration;
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;

    public class SkyScanner : IDataSupplier
    {
        public SearchFlightResponse SearchFlight(SearchFlightRequest request)
        {
            // required fields
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

            uri += string.Format("?apiKey={0}", "prtl6749387986743898559646983194");

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
                            response = JsonHelper.Deserialize<SearchFlightResponse>(text);
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
}

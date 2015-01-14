using System;
using System.IO;
using System.Net;
using System.Text;

namespace FairFlights.DataConsumer.Suppliers
{
    using FairFlights.Configuration;
    using FairFlights.DataConsumer.Interfaces;
    using FairFlights.DomainObjects.Flight;

    public class WegoFlights : IDataSupplier
    {
        public SearchFlightResponse SearchFlight(SearchFlightRequest request)
        {
            throw new NotImplementedException();
        }


        public SearchResponse SearchWegoFlight(SearchRequest request)
        {
            var uri = AppSettings.WegoUri + "searches?" + "api_key=your_secret_api_key&ts_code=your_secret_ts_code";

            var query = BuildJsonQuery(request);

            var webReq = WebRequest.Create(uri);
            webReq.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(query);
            webReq.ContentType = "application/json";
            //webReq.Headers["Accept"] = "application/json";
            webReq.ContentLength = byteArray.Length;

            using (var requestStream = webReq.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }
            string returnContent;

            using (var responseStream = new StreamReader(webReq.GetResponse().GetResponseStream()))
            {
                returnContent = responseStream.ReadToEnd();
            }

            return new SearchResponse();
        }

        private string BuildJsonQuery(SearchRequest request)
        {
            // build json query
            var query = new StringBuilder();
            var tripQuery = "{" + string.Format("\"departure_code\": \"{0}\",\"arrival_code\":\"{1}\",\"outbound_date\":\"{2}\",\"inbound_date\":\"{3}\"",
                request.DepartureCode, request.ArrivalCode, request.OutboundDate, request.InboundDate) + "}";

            query.Append("{");

            query.AppendFormat("\"trips\":[{0}]", tripQuery);

            if (!string.IsNullOrEmpty(request.AdultsCount))
            {
                query.AppendFormat(",\"adults_count\":{0}", request.AdultsCount);
            }

            if (!string.IsNullOrEmpty(request.ChildrenCount))
            {
                query.AppendFormat(",\"children_count\":{0}", request.ChildrenCount);
            }

            if (!string.IsNullOrEmpty(request.Cabin))
            {
                query.AppendFormat(",\"cabin\":{0}", request.Cabin);
            }

            if (!string.IsNullOrEmpty(request.UserCountryCode))
            {
                query.AppendFormat(",\"user_country_code\":{0}", request.UserCountryCode);
            }

            if (!string.IsNullOrEmpty(request.CountrySiteCode))
            {
                query.AppendFormat(",\"country_site_code\":{0}", request.CountrySiteCode);
            }

            query.Append("}");

            return query.ToString();
        }
    }
}

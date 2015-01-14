namespace FairFlights.Common
{
    using Newtonsoft.Json;

    public class JsonHelper
    {
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}

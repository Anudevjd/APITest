using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace APITest.Util
{
    public static class Utilities
    {
        public static JObject GetResponseObject(this IRestResponse Resresponse)
        {
            JObject obj = JObject.Parse(Resresponse.Content);
            return obj;
        }

        public static Dictionary<string,string> DeserialiseResponse(this IRestResponse Restresponse)
        {
            var JsonObj = new JsonDeserializer().Deserialize<Dictionary<string, string>>(Restresponse);
           
            return JsonObj;

        }

       
    }
}

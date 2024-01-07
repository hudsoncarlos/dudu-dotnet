using Newtonsoft.Json;
using RestSharp;
using Service.Service;
using System.Collections.Generic;

namespace Service.Helper.ApiHelper
{
    public class RequestApiHelper
    {
        internal static T MakeRequest<T>(Method method, string endPoint, string route, Dictionary<string, object> parameters) where T : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(RequestApi.ConsumerApi(method, endPoint, route, parameters));
            }
            catch
            {
                return new T();
            }
        }
    }
}

using RestSharp;
using Service.Service.Methods;
using System.Collections.Generic;

namespace Service.Service
{
    public class RequestApi
    {
        public static string ConsumerApi(Method method, string endPoint, string route, Dictionary<string, object> parameters)
        {
            try
            {
                var result = string.Empty;

                if (string.IsNullOrEmpty(endPoint))
                    return string.Empty;

                switch (method)
                {
                    case Method.Get:
                        return new ConsumerApiFactory(new GetApiService(method, endPoint, route, parameters)).Execute();
                    case Method.Post:
                    case Method.Put:
                    case Method.Delete:
                    case Method.Head:
                    case Method.Options:
                    case Method.Patch:
                    case Method.Merge:
                    case Method.Copy:
                    default:
                        return string.Empty;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

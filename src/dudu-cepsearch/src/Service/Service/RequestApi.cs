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
                    case Method.GET:
                        return new ConsumerApiFactory(new GetApiService(method, endPoint, route, parameters)).Execute();
                    case Method.POST:
                    case Method.PUT:
                    case Method.DELETE:
                    case Method.HEAD:
                    case Method.OPTIONS:
                    case Method.PATCH:
                    case Method.MERGE:
                    case Method.COPY:
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

using Domain.Model;
using RestSharp;
using System.Collections.Generic;

namespace Service.Service.Methods
{
    public class GetApiService : ApiTemplateMethodAbstract
    {
        public GetApiService(Method method, string endPoint, string route, Dictionary<string, object> parameters)
        {
            EndPoint = endPoint;
            Parameters = parameters;

            RestRequestApi = new RestRequest
            {
                Resource = route,
                Method = method
            };
        }

        public override string Consumer()
        {
            if (!string.IsNullOrEmpty(Token))
                RestRequestApi.AddHeader("Authorization", string.Format("Bearer {0}", Token));

            //if (Parameters != null && Parameters.Count > 0)
            //    foreach (KeyValuePair<string, object> item in Parameters)
            //        RestRequestApi.AddParameter(item.Key.ToString(), item.Value, false);

            return ExecuteRequest(RestRequestApi).Content;
        }
    }
}

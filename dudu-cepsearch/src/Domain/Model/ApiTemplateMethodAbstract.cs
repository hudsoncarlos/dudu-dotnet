using Domain.Interface.Service;
using RestSharp;
using System.Collections.Generic;

namespace Domain.Model
{
    public abstract class ApiTemplateMethodAbstract : IMethodConsumer
    {
        public RestRequest RestRequestApi { get; set; }
        public string EndPoint { get; set; }
        public string Token{ get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        
        public abstract string Consumer();

        public virtual RestResponse ExecuteRequest(RestRequest request)
        {
            var response = new RestClient(EndPoint).Execute(request);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Continue:
                case System.Net.HttpStatusCode.SwitchingProtocols:
                case System.Net.HttpStatusCode.Processing:
                case System.Net.HttpStatusCode.EarlyHints:
                case System.Net.HttpStatusCode.OK:
                    return response;
                case System.Net.HttpStatusCode.Created:
                case System.Net.HttpStatusCode.Accepted:
                case System.Net.HttpStatusCode.NonAuthoritativeInformation:
                case System.Net.HttpStatusCode.NoContent:
                case System.Net.HttpStatusCode.ResetContent:
                case System.Net.HttpStatusCode.PartialContent:
                case System.Net.HttpStatusCode.MultiStatus:
                case System.Net.HttpStatusCode.AlreadyReported:
                case System.Net.HttpStatusCode.IMUsed:
                case System.Net.HttpStatusCode.Ambiguous:
                case System.Net.HttpStatusCode.Moved:
                case System.Net.HttpStatusCode.Found:
                case System.Net.HttpStatusCode.RedirectMethod:
                case System.Net.HttpStatusCode.NotModified:
                case System.Net.HttpStatusCode.UseProxy:
                case System.Net.HttpStatusCode.Unused:
                case System.Net.HttpStatusCode.RedirectKeepVerb:
                case System.Net.HttpStatusCode.PermanentRedirect:
                case System.Net.HttpStatusCode.BadRequest:
                case System.Net.HttpStatusCode.Unauthorized:
                case System.Net.HttpStatusCode.PaymentRequired:
                case System.Net.HttpStatusCode.Forbidden:
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.MethodNotAllowed:
                case System.Net.HttpStatusCode.NotAcceptable:
                case System.Net.HttpStatusCode.ProxyAuthenticationRequired:
                case System.Net.HttpStatusCode.RequestTimeout:
                case System.Net.HttpStatusCode.Conflict:
                case System.Net.HttpStatusCode.Gone:
                case System.Net.HttpStatusCode.LengthRequired:
                case System.Net.HttpStatusCode.PreconditionFailed:
                case System.Net.HttpStatusCode.RequestEntityTooLarge:
                case System.Net.HttpStatusCode.RequestUriTooLong:
                case System.Net.HttpStatusCode.UnsupportedMediaType:
                case System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
                case System.Net.HttpStatusCode.ExpectationFailed:
                case System.Net.HttpStatusCode.MisdirectedRequest:
                case System.Net.HttpStatusCode.UnprocessableEntity:
                case System.Net.HttpStatusCode.Locked:
                case System.Net.HttpStatusCode.FailedDependency:
                case System.Net.HttpStatusCode.UpgradeRequired:
                case System.Net.HttpStatusCode.PreconditionRequired:
                case System.Net.HttpStatusCode.TooManyRequests:
                case System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge:
                case System.Net.HttpStatusCode.UnavailableForLegalReasons:
                case System.Net.HttpStatusCode.InternalServerError:
                case System.Net.HttpStatusCode.NotImplemented:
                case System.Net.HttpStatusCode.BadGateway:
                case System.Net.HttpStatusCode.ServiceUnavailable:
                case System.Net.HttpStatusCode.GatewayTimeout:
                case System.Net.HttpStatusCode.HttpVersionNotSupported:
                case System.Net.HttpStatusCode.VariantAlsoNegotiates:
                case System.Net.HttpStatusCode.InsufficientStorage:
                case System.Net.HttpStatusCode.LoopDetected:
                case System.Net.HttpStatusCode.NotExtended:
                case System.Net.HttpStatusCode.NetworkAuthenticationRequired:
                default:
                    return response;
            }
        }
    }
}

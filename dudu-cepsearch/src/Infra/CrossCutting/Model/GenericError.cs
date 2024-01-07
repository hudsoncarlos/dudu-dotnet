using Newtonsoft.Json;

namespace CrossCutting.Model
{
    public class GenericError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}

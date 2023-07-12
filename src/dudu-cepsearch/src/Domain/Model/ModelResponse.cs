namespace Domain.Model
{
    public class ModelResponse<T>
    {
        public T Data { get; set; }
        public bool Sucess { get; set; }
        public string ErrorDescription { get; set; }
    }
}

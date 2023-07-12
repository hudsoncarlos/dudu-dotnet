using Domain.Interface.Service;

namespace Service.Service
{
    public class ConsumerApiFactory
    {
        public IMethodConsumer _methodConsumer { get; set; }

        public ConsumerApiFactory(IMethodConsumer methodConsumer)
            => _methodConsumer = methodConsumer;

        public string Execute()
            => _methodConsumer.Consumer();
    }
}

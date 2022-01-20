using PingPongClient.ObjectProviders;
using PingPongClient.Output;
using PingPongClient.ServerContact;

namespace PingPongClient
{
    public class ClientFactory
    {
        public PingPongClient<T> Create<T>()
        {
            var objectProvider = new PersonProvider();
            var serverContact = new TcpContact<T>();
            var output = new ConsoleOutput();

            return new PingPongClient<T>(objectProvider, serverContact, output);
        }
    }
}

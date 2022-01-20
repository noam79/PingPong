using PingPongClient.ObjectProviders;
using PingPongClient.Output;
using PingPongClient.ServerContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

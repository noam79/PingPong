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
        public Client Create()
        {
            var objectProvider = new ConsoleStringProvider();
            var serverContact = new SocketContact();
            var output = new ConsoleOutput();

            return new Client(objectProvider, serverContact, output);
        }
    }
}

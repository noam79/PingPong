using PingPongClient.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient
{
    public class Client
    {
        private IObjectProvider _objectProvider;
        private IServerContact _serverContact;

        private IOutput _output;

        private bool _run;

        public Client(IObjectProvider objectProvider, IServerContact serverContact, IOutput output)
        {
            _objectProvider = objectProvider;
            _serverContact = serverContact;
            _output = output;
        }

        public void Communicate(string ip, int port)
        {
            _serverContact.Connect(ip, port);
            while (_run)
            {
                _serverContact.Send(_objectProvider.GetObject());
                _output.Write(_serverContact.Recieve().ToString());
            }
        }

        public void Stop()
        {
            _run = false;
        }
    }
}

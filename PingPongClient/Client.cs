using PingPongClient.ObjectProviders;
using PingPongClient.Output;
using PingPongClient.ServerContact;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient
{
    public class Client<T>
    {
        private IObjectProvider _objectProvider;
        private IServerContact<T> _serverContact;

        private IOutput _output;

        private bool _run;

        public Client(IObjectProvider objectProvider, IServerContact<T> serverContact, IOutput output)
        {
            _objectProvider = objectProvider;
            _serverContact = serverContact;
            _output = output;
        }

        public void Communicate(string ip, int port)
        {
            _run = true;

            var maxMessageSize = int.Parse(ConfigurationManager.AppSettings["maxServerMessageSize"]);

            _serverContact.Connect(ip, port);
            while (_run)
            {
                _serverContact.Send(_objectProvider.GetObject());
                _output.Write(_serverContact.Recieve(maxMessageSize).ToString());
            }
        }

        public void Stop()
        {
            _run = false;
        }
    }
}

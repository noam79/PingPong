using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.ServerContact
{
    public interface IServerContact : IDisposable
    {
        public void Connect(string ip, int port);

        public void Send(object obj);

        public object Recieve(int maxMessageSize);
    }
}

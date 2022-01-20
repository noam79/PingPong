using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.ServerContact
{
    public interface IServerContact<T> : IDisposable
    {
        public void Connect(string ip, int port);

        public void Send(object obj);

        public T Recieve(int maxMessageSize);
    }
}

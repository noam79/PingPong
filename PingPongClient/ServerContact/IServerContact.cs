using System;

namespace PingPongClient.ServerContact
{
    public interface IServerContact<T> : IDisposable
    {
        public void Connect(string ip, int port);

        public void Send(object obj);

        public T Recieve(int maxMessageSize);
    }
}

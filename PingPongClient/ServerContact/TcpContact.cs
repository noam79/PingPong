using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Newtonsoft;
using System.Threading.Tasks;

namespace PingPongClient.ServerContact
{
    public class TcpContact<T> : IServerContact<T>
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public void Connect(string ip, int port)
        {
            _client = new(ip, port);
            _stream = _client.GetStream();
        }

        public void Send(object obj)
        {
            var message = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            _stream.Write(
                Encoding.ASCII.GetBytes(message),
                0,
                message.Length
                );
        }

        public T Recieve(int maxMessageSize)
        {
            var rawData = new byte[2048];

            int dataReceived = _stream.Read(rawData, 0, rawData.Length);
            var message = Encoding.ASCII.GetString(rawData, 0, dataReceived);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);
        }

        public void Dispose()
        {
            _client.Close();
        }
    }
}

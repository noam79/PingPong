using System;

namespace PingPongClient.ObjectProviders
{
    public class ConsoleStringProvider : IObjectProvider
    {
        public object GetObject()
        {
            return Console.ReadLine();
        }
    }
}

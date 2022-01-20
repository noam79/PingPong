using System;

namespace PingPongClient.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}

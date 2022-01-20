using PingPongClient.Utilities;

namespace PingPongClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ClientFactory();
            var client = factory.Create<Person>();

            client.Communicate(args[0], int.Parse(args[1]));
        }
    }
}

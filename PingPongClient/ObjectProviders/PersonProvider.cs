using PingPongClient.Utilities;
using System;

namespace PingPongClient.ObjectProviders
{
    public class PersonProvider : IObjectProvider
    {
        public object GetObject()
        {
            Console.Write("Enter Name And Age: ");
            return new Person(
                Console.ReadLine(),
                int.Parse(Console.ReadLine())
                );
        }
    }
}

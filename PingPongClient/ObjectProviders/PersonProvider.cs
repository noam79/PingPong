using PingPongClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

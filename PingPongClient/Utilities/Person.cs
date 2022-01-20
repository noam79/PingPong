using Newtonsoft.Json;

namespace PingPongClient.Utilities
{
    public class Person
    {
        [JsonProperty]
        private string _name;

        [JsonProperty]
        private int _age;

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{ _name} is { _age } years old.";
        }
    }
}

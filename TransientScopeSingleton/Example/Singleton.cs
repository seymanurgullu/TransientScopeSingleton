using System;

namespace TransientScopeSingleton.Example
{
    public class Singleton:ISingleton
    {
        public int Number { get; set; }
        public Singleton()
        {
            Random random = new Random();
            Number = random.Next();
        }
        public int Random()
        {
            return Number;
        }
    }
}

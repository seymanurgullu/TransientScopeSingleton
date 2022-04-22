using System;

namespace TransientScopeSingleton.Example
{
    public class Transient:ITransient
    {
        public int Number { get; set; }
        public Transient()
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

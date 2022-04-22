using System;

namespace TransientScopeSingleton.Example
{
    public class Scoped:IScoped
    {
        public int Number { get; set; }
        public Scoped()
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

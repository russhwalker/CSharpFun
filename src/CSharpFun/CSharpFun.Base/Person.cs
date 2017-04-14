using System;

namespace CSharpFun.Base
{
    public class Person : INoisy
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var p = (Person) obj;
            return p.FirstName == this.FirstName &&
                   p.LastName == this.LastName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void MakeNoise()
        {
            Console.WriteLine("Hello");
        }

    }
}

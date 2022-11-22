using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    public class Person : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class Prototype
    {
        public static void TestPersonPrototype()
        {
            Person p1 = new Person
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Person p2 = p1.Clone() as Person;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    public class Adapter
    {
        public class Adaptee
        {
            public string GetRequest()
            {
                return "Request from the client";
            }
        }

        public interface ITarget
        {
            string Request();
        }

        public class AdapterClass : ITarget
        {
            private readonly Adaptee adaptee;

            public AdapterClass(Adaptee adaptee)
            {
                this.adaptee = adaptee;
            }

            public string Request()
            {
                return $"This is {this.adaptee.GetRequest()}";
            }
        }
    }
}

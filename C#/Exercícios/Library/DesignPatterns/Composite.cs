using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    public class Composite
    {
        public abstract class Component
        {
            public abstract void AddChild(Component c);
            public abstract void Traverse();
        }

        public class File : Component
        {
            private string value = string.Empty;

            public File(string value)
            {
                this.value = value;
            }

            public override void AddChild(Component c) { }

            public override void Traverse()
            {
                Console.WriteLine("File: " + value);
            }
        }

        public class Folder : Component
        {
            private string value = string.Empty;
            private List<Component> componentList = new List<Component>();

            public Folder(string value)
            {
                this.value = value;
            }

            public override void AddChild(Component c)
            {
                componentList.Add(c);
            }

            public override void Traverse()
            {
                Console.WriteLine("Folder: " + value);
                foreach (Component c in componentList)
                {
                    c.Traverse();
                }
            }
        }
    }
}

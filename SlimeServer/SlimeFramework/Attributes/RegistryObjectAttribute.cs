using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlimeFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RegistryObjectAttribute : Attribute
    {
        readonly string name;

        public RegistryObjectAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}

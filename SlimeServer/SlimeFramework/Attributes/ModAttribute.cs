using System;

namespace SlimeFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ModAttribute : Attribute
    {
        readonly string name;

        public ModAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}

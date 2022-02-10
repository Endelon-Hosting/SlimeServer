using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlimeFramework
{
    public class SlimeObject
    {
        public SlimeObject()
        {

        }

        public RegistryLocation RegistryName { get; set; }

        public void SetRegistryName(string name)
        {
            var mod = name.Split(":").FirstOrDefault();
            CheckIfModExists(mod);
            var id = name.Remove(0, mod.Length + 1);
            RegistryName = new(mod, id);
        }

        private void CheckIfModExists(string mod)
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void Register()
        {

        }
    }
}

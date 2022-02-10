namespace SlimeFramework
{
    public struct RegistryLocation
    {
        public string GetFullName()
        {
            return $"{Mod}:{Name}";
        }

        public string Mod { get; set; }
        public string Name { get; set; }

        public RegistryLocation(string mod, string name)
        {
            Mod = mod;
            Name = name;
        }

        public static bool operator ==(RegistryLocation a, RegistryLocation b)
        {
            return a.GetFullName() == b.GetFullName();
        }

        public static bool operator !=(RegistryLocation a, RegistryLocation b)
        {
            return a.GetFullName() != b.GetFullName();
        }

        public override bool Equals(object obj)
        {
            if(obj is RegistryLocation rl)
            {
                return rl == this;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return GetFullName().GetHashCode();
        }
    }
}
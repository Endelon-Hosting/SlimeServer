namespace SlimeFramework.Internal
{
    public abstract class SlimeRegistryCollection<T> where T : SlimeObject
    {
        public abstract void Register(T obj);
        public abstract void Unregister(T obj);
        public abstract T Get(RegistryLocation location);
    }
}
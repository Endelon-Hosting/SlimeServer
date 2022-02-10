using SlimeFramework.GameContent;


namespace SlimeFramework.Internal
{
    public abstract class SlimeRegistry
    {
        public static SlimeRegistry Instance
        {
            get
            {
                return SlimeFramework.SlimeRegistry.Instance;
            }
            set
            {
                SlimeFramework.SlimeRegistry.Instance = value;
            }
        }

        public abstract void Register<T>(T instance) where T : SlimeObject;

        public abstract SlimeRegistryCollection<Block> Blocks { get; }
        public abstract SlimeRegistryCollection<Biome> Biomes { get; }
        public abstract SlimeRegistryCollection<Item> Items { get; }
        public abstract SlimeRegistryCollection<Food> Foods { get; }
        public abstract SlimeRegistryCollection<Fuel> Fuels { get; }
    }
}

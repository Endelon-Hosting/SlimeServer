using SlimeFramework.GameContent;
using SlimeFramework.Internal;

namespace SlimeServer.ModdingEngine
{
    public class SlimeRegistryImpl : SlimeRegistry
    {
        #region Constructor
        public SlimeRegistryImpl()
        {
            Instance = this;

            var blocks = new SlimeRegistryCollectionImpl<Block>();
            var biomes = new SlimeRegistryCollectionImpl<Biome>();
            var items = new SlimeRegistryCollectionImpl<Item>();
            var foods = new SlimeRegistryCollectionImpl<Food>();
            var fuels = new SlimeRegistryCollectionImpl<Fuel>();

            blocks.ObjectAdded += Blocks_ObjectAdded;
            blocks.ObjectRemoved += Blocks_ObjectRemoved;
            biomes.ObjectAdded += Biomes_ObjectAdded;
            biomes.ObjectRemoved += Biomes_ObjectRemoved;
            items.ObjectAdded += Items_ObjectAdded;
            items.ObjectRemoved += Items_ObjectRemoved;
            foods.ObjectAdded += Foods_ObjectAdded;
            foods.ObjectRemoved += Foods_ObjectRemoved;
            fuels.ObjectAdded += Fuels_ObjectAdded;
            fuels.ObjectRemoved += Fuels_ObjectRemoved;

            Blocks = blocks;
            Biomes = biomes;
            Items = items;
            Foods = foods;
            Fuels = fuels;
        }
        #endregion
        #region RegistryHandlers
        private void Fuels_ObjectRemoved(object sender, Fuel t)
        {

        }

        private void Fuels_ObjectAdded(object sender, Fuel t)
        {

        }

        private void Foods_ObjectRemoved(object sender, Food t)
        {

        }

        private void Foods_ObjectAdded(object sender, Food t)
        {

        }

        private void Items_ObjectRemoved(object sender, Item t)
        {

        }

        private void Items_ObjectAdded(object sender, Item t)
        {

        }

        private void Biomes_ObjectRemoved(object sender, Biome t)
        {

        }

        private void Biomes_ObjectAdded(object sender, Biome t)
        {

        }

        private void Blocks_ObjectRemoved(object sender, Block t)
        {

        }

        private void Blocks_ObjectAdded(object sender, Block t)
        {

        }
        #endregion
        #region Collections
        public override SlimeRegistryCollection<Block> Blocks { get; }
        public override SlimeRegistryCollection<Biome> Biomes { get; }
        public override SlimeRegistryCollection<Item> Items { get; }
        public override SlimeRegistryCollection<Food> Foods { get; }
        public override SlimeRegistryCollection<Fuel> Fuels { get; }
        #endregion
        #region RegisterAny
        public override void Register<T>(T t)
        {
            if (t is Block block)
            {
                Blocks.Register(block);
            }
            else if (t is Biome biome)
            {
                Biomes.Register(biome);
            }
            else if (t is Item item)
            {
                Items.Register(item);
            }
            else if (t is Food food)
            {
                Foods.Register(food);
            }
            else if (t is Fuel fuel)
            {
                Fuels.Register(fuel);
            }
        }
        #endregion
    }
}
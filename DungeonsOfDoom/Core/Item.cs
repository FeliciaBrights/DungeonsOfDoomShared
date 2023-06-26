namespace DungeonsOfDoom.Core
{
    abstract class Item : ICollectible
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

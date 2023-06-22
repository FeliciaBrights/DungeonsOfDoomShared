namespace DungeonsOfDoom.Core
{
    class Player : Entity
    {
        public Player() : base(MaxHealth)
        {
        }

        public const int MaxHealth = 30;

        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Inventory { get; } = new List<Item>();


    }
}

namespace DungeonsOfDoom.Core
{
    class Player
    {
        public const int MaxHealth = 30;
        public Player()
        {
            Health = MaxHealth;
        }

        public int Health { get; set; }
        public bool IsAlive { get { return Health > 0; } }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Inventory { get; } = new List<Item>();


    }
}

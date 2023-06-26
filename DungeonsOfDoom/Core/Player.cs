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

        public override void Attack(Entity opponent)
        {
            Item gloves = Inventory.OfType<GlovesOfMetal>().FirstOrDefault();
            if (gloves != null)
            {
                opponent.Health -= 15;
                Inventory.Remove(gloves);
            }
            else
            {
                opponent.Health -= 10;
            }
        }

        public void TeleportAndHeal(int x, int y)
        {
            Health += 5;

            X = RandomUtils.SpawnChance(0, x);
            Y = RandomUtils.SpawnChance(0, y);

        }
    }
}

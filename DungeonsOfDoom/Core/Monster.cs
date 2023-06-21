namespace DungeonsOfDoom.Core
{
    class Monster
    {
        public Monster(int health)
        {
            Name = GenerateMonsterName();
            Health = health;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive { get { return Health > 0; } }

        public string GenerateMonsterName()
        {
            string[] monster = { "Skeleton", "Mummy", "Ghost"};
            return monster[Random.Shared.Next(3)];
        }

    }
}

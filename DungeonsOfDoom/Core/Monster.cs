namespace DungeonsOfDoom.Core
{
    class Monster : Entity
    {
        public Monster(int health) : base(health)
        {
            Name = GenerateMonsterName();
        }

        public string Name { get; set; }

        public string GenerateMonsterName()
        {
            string[] monster = { "Skeleton", "Mummy", "Ghost"};
            return monster[Random.Shared.Next(3)];
        }

    }
}

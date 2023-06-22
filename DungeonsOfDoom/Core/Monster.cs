namespace DungeonsOfDoom.Core
{
    abstract class Monster : Entity
    {
        public Monster(int health, string name) : base(health)
        {
            Name = name;
        }

        public string Name { get; }

    }
}

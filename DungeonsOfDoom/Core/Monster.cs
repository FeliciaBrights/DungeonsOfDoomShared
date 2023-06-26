namespace DungeonsOfDoom.Core
{
    abstract class Monster : Entity
    {
        public Monster(int health, string name) : base(health)
        {
            Name = name;
            MonsterCounter++;
        }

        public string Name { get; }
        public static int MonsterCounter { get; set; }
       
    }
}

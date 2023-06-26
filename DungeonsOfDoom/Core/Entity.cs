using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    abstract class Entity
    {


        public int MaxHealth { get; set; }

        private int health;

        public int Health
        {
            get { return health; }
            set
            {
                if (value > 0 && value <= 30)
                {
                    health = value;
                }
            }
        }


        public bool IsAlive { get { return Health > 0; } }

        public Entity(int health)
        {
            MaxHealth = health;
            Health = health;
        }

        public abstract void Attack(Entity opponent);
    }
}

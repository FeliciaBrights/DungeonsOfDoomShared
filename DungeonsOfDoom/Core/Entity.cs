using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    abstract class Entity
    {

        public int Health { get; set; }
        public bool IsAlive { get { return Health > 0; } }

        public Entity(int health)
        {
            Health = health;
        }
    }
}

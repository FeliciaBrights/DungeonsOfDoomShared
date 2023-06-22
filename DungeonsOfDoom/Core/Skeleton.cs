using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    internal class Skeleton : Monster
    {
        public Skeleton() : base(20, "Skeleton")
        {
        }
        public override void Attack(Entity opponent)
        {
            if (opponent.Health >= Health * 2)
                opponent.Health -= 1;
            else
                opponent.Health -= 5;
        }
    }
}

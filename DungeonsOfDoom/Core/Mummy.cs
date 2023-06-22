using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    internal class Mummy : Monster
    {
        public Mummy() : base(15, "Mummy")
        {
        }

        public override void Attack(Entity opponent)
        {
            opponent.Health -= 10;

        }
    }
}

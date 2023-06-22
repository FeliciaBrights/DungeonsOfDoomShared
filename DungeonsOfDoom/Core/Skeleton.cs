using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    internal class Skeleton : Monster
    {
        public Skeleton(int health) : base(health, Name)
        {
        }
        
        public const string Name = "Skeleton";
    }
}

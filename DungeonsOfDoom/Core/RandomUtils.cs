using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    static class RandomUtils
    {
        public static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        public static int SpawnChance(int lowerBound, int upperBound)
        {
           return Random.Shared.Next(lowerBound, upperBound);
        }
    }
}

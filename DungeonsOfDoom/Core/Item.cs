﻿namespace DungeonsOfDoom.Core
{
    abstract class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

﻿using P03_BarraksWars.Models.Units;

namespace P03_BarraksWars.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;

        public Archer() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Models.Units
{
   public  class Horseman : Unit
    {
        private const int health = 50;
        private const int attackDamage = 10;
        public Horseman() 
            : base(health, attackDamage)
        {
        }
    }
}

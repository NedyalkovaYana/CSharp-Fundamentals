using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character : ICharacter
    {
        private const string AliveStatus = "Alive";
        private const string DeadStatus = "Dead";
        private const double RestHealMultiplierDefault = 0.2;
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private IBag bag;
        private Faction faction;

        protected Character(string name, double health, double armor, double abilityPoints,
            IBag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Messages.ExceptionMessegeForWrongName);
                }

                this.name = value;
            }
        }
        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            private set
            {
                this.baseHealth = value;
            }
        }
        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = Math.Min(value, this.BaseHealth);
            }
        }
        
        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            private set
            {
                this.baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }
        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            private set
            {
                this.abilityPoints = value;
            }
        }
        public IBag Bag { get; }
        public Faction Faction { get; }
        public bool IsAlive { get; set; } = true;
        public virtual double RestHealMultiplier => (double) 1 / 5;

        public void TakeDamage(double hitPoints)
        {
            this.EnshureAlive();

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);
            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {

            this.EnshureAlive();

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);

        }

        public void UseItem(IItem item)
        {
            this.EnshureAlive();

            UseItemOn(item, this);
        }

        public void UseItemOn(IItem item, ICharacter character)
        {
           item.AffectCharacter(character);
        }

        public void GiveCharacterItem(IItem item, ICharacter character)
        {
            character.ReceiveItem(item);
        }

        public void ReceiveItem(IItem item)
        {
            this.Bag.AddItem(item);
        }

        public string CharacterToString()
        {
            string status = string.Empty;
            if (this.IsAlive == true)
            {
                status = AliveStatus;
            }
            else
            {
                status = DeadStatus;
            }
            return String.Format(Messages.CharacterToString, Name, this.Health, this.BaseHealth,
                this.Armor, this.BaseArmor, status);
        }

        protected void EnshureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Messages.MustBeAliveMessage);
            }
        }
    }
}

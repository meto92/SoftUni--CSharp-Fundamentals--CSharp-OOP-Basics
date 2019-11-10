using System;

using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Core.Enums;
using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Characters
{
    [Character]
    public abstract class Character : ICharacter
    {
        private const double DefaultRestHealMultiplier = 0.2;

        private const string InvalidNameExceptionMessage = "Name cannot be null or whitespace!";
        private const string DeadCharacterExceptionMessage = "Must be alive to perform this action!";

        private string name;
        private double health;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;

        protected Character(
            string name,
            double health,
            double armor,
            double abilityPoints,
            Bag bag,
            Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public abstract double BaseHealth
        {
            get;
        }

        public double Health
        {
            get => this.health;

            set
            {
                this.health = Math.Max(0, Math.Min(this.BaseHealth, value));

                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public abstract double BaseArmor
        {
            get;
        }

        public double Armor
        {
            get => this.armor;
            set => this.armor = Math.Max(0, Math.Min(this.BaseArmor, value));
        }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set => this.abilityPoints = value;
        }

        public Bag Bag
        {
            get => this.bag;
            private set => this.bag = value;
        }

        public Faction Faction
        {
            get => this.faction;
            private set => this.faction = value;
        }

        public bool IsAlive
        {
            get => this.isAlive;
            private set => this.isAlive = value;
        }

        public virtual double RestHealMultiplier => DefaultRestHealMultiplier;

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(DeadCharacterExceptionMessage);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double rest = this.Armor - hitPoints;

            this.Armor -= hitPoints;

            if (rest < 0)
            {
                this.Health += rest;
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.EnsureAlive();

            this.Bag.AddItem(item);
        }

        public void Rest()
        {
            this.EnsureAlive();

            this.Health += this.BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();

            item.AffectCharacter(character);
        }

        public override string ToString()
        {
            string result = string.Format("{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}",
                this.Name,
                this.Health,
                this.BaseHealth,
                this.Armor,
                this.BaseArmor,
                this.IsAlive ? "Alive" : "Dead");

            return result;
        }
    }
}
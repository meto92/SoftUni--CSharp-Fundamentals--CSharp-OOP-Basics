namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Text;
    using System.Linq;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;
    using System.Collections.Generic;

    public abstract class Starship : IStarship
    {
        private string name;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private StarSystem location;
        private List<Enhancement> enhancements;

        public Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Health
        {
            get => this.health;
            set => this.health = Math.Max(0, value);
        }

        public int Shields
        {
            get => this.shields;
            set => this.shields = Math.Max(0, value);
        }

        public int Damage
        {
            get => this.damage;
            set => this.damage = value;
        }

        public double Fuel
        {
            get => this.fuel;
            set => this.fuel = value;
        }

        public StarSystem Location
        {
            get => this.location;
            set => this.location = value;
        }

        public IEnumerable<Enhancement> Enhancements => this.enhancements;

        public void AddEnhancement(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);

            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--{this.Name} - {this.GetType().Name}");

            if (this.Health == 0)
            {
                sb.Append("(Destroyed)");
            }
            else
            {
                sb.AppendLine($"-Location: {this.Location.Name}");
                sb.AppendLine($"-Health: {this.Health}");
                sb.AppendLine($"-Shields: {this.Shields}");
                sb.AppendLine($"-Damage: {this.Damage}");
                sb.AppendLine($"-Fuel: {this.Fuel:f1}");
                sb.Append(string.Format("-Enhancements: {0}",
                    this.enhancements.Count == 0 ? "N/A" : string.Join(", ", this.Enhancements.Select(e => e.Name))));
            }

            return sb.ToString();
        }
    }
}
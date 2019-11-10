using System;
using System.Text;

using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit : IUnit
    {
        private string name;
        private int x;
        private int y;
        private int attackPoints;
        private int heatlhPonts;
        private int defensePoints;
        private int energyPoints;
        private int range;
        private ICombatHandler combatHandler;

        protected Unit(
            string name,
            int x,
            int y, 
            int attackPower, 
            int healthPoints, 
            int defensePoints, 
            int energyPoints, 
            int range)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.AttackPoints = attackPower;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
            this.Range = range;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int X
        {
            get => this.x;
            set => this.x = value;
        }
        
        public int Y
        {
            get => this.y;
            set => this.y = value;
        }
        
        public int AttackPoints
        {
            get => this.attackPoints;
            set => this.attackPoints = value;
        }
        
        public int HealthPoints
        {
            get => this.heatlhPonts;
            set => this.heatlhPonts = value;
            //set => this.heatlhPonts = Math.Max(0, value);
        }

        public int DefensePoints
        {
            get => this.defensePoints;
            set => this.defensePoints = value;
        }

        public int EnergyPoints
        {
            get => this.energyPoints;
            set => this.energyPoints = value;
        }

        public int Range
        {
            get => this.range;
            private set => this.range = value;
        }

        public ICombatHandler CombatHandler
        {
            get => this.combatHandler;
            set => this.combatHandler = value;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})");

            if (this.HealthPoints == 0)
            {
                result.Append("(Dead)");
            } 
            else
            {
                result.AppendLine($"-Health points = {this.HealthPoints}");
                result.AppendLine($"-Attack points = {this.AttackPoints}");
                result.AppendLine($"-Defense points = {this.DefensePoints}");
                result.AppendLine($"-Energy points = {this.EnergyPoints}");
                result.Append($"-Range = {this.Range}");
            }

            return result.ToString();
        }
    }
}
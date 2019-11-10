using System;

using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Core.Enums;
using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Characters
{
    [Character]
    public class Warrior : Character, IAttackable
    {
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorAbilityPoints = 40;

        private const string AttackSelfExceptionMessage = "Cannot attack self!";
        private const string FriendlyFireExceptionMessage = "Friendly fire! Both characters are from {0} faction!";

        public Warrior(string name, Faction faction)
            : base(
                name,
                WarriorBaseHealth,
                WarriorBaseArmor,
                WarriorAbilityPoints,
                new Satchel(),
                faction)
        { }

        public override double BaseHealth => WarriorBaseHealth;

        public override double BaseArmor => WarriorBaseArmor;

        public void Attack(Character character)
        {
            base.EnsureAlive();
            character.EnsureAlive();

            if (this == character)
            {
                throw new InvalidOperationException(AttackSelfExceptionMessage);
            }

            if (base.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(
                    FriendlyFireExceptionMessage, 
                    base.Faction));
            }

            character.TakeDamage(base.AbilityPoints);
        }
    }
}
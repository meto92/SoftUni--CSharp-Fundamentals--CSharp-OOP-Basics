using System;

using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Core.Enums;
using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Characters
{
    [Character]
    public class Cleric : Character, IHealable
    {
        private const double ClericBaseHealth = 50;
        private const double ClericBaseArmor = 25;
        private const double ClericAbilityPoints = 40;
        private const double ClericRestHealthMultiplier = 0.5;

        private const string HealingEnemyCharacterExceptionMessage = "Cannot heal enemy character!";

        public Cleric(string name, Faction faction)
            : base(
                  name, 
                  ClericBaseHealth, 
                  ClericBaseArmor, 
                  ClericAbilityPoints, 
                  new Backpack(),
                  faction)
        { }

        public override double BaseHealth => ClericBaseHealth;

        public override double BaseArmor => ClericBaseArmor;

        public override double RestHealMultiplier => ClericRestHealthMultiplier;

        public void Heal(Character character)
        {
            base.EnsureAlive();
            character.EnsureAlive();

            if (base.Faction != character.Faction)
            {
                throw new InvalidOperationException(HealingEnemyCharacterExceptionMessage);
            }

            character.Health += base.AbilityPoints;
        }
    }
}
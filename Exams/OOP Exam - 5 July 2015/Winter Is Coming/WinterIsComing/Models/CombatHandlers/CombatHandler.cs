using System.Collections.Generic;

using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.CombatHandlers
{
    public abstract class CombatHandler : ICombatHandler
    {
        private IUnit unit;

        protected CombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit
        {
            get => this.unit;
            set => this.unit = value;
        }

        protected void TakeEnergy(ISpell spell)
        {
            if (spell.EnergyCost > this.Unit.EnergyPoints)
            {
                throw new NotEnoughEnergyException(string.Format(
                    GlobalMessages.NotEnoughEnergy, 
                    Unit.Name, 
                    spell.GetType().Name));
            }

            this.Unit.EnergyPoints -= spell.EnergyCost;
        }

        public abstract ISpell GenerateAttack();

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);
    }
}
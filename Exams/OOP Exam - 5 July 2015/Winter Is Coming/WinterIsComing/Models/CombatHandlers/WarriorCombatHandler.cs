using System.Linq;
using System.Collections.Generic;

using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class WarriorCombatHandler : CombatHandler, ICombatHandler
    {
        public WarriorCombatHandler(IUnit warrior)
            : base(warrior)
        { }

        public override ISpell GenerateAttack()
        {
            int damage = base.Unit.AttackPoints;

            if (base.Unit.HealthPoints <= 80)
            {
                damage += 2 * base.Unit.HealthPoints;
            }

            ISpell spell = new Cleave(damage);

            if (base.Unit.HealthPoints > 50)
            {
                base.TakeEnergy(spell); 
            }

            return new Cleave(damage);
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            List<IUnit> targets = new List<IUnit>();

            if (candidateTargets.Any())
            {
                targets.Add(candidateTargets
                    .OrderBy(target => target.HealthPoints)
                    .ThenBy(target => target.Name)
                    .First());
            }

            return targets;
        }
    }
}
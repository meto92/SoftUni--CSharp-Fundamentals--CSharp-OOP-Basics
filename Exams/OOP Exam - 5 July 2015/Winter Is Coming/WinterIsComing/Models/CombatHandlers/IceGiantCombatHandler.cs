using System.Linq;
using System.Collections.Generic;

using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class IceGiantCombatHandler : CombatHandler
    {
        public IceGiantCombatHandler(IUnit unit) 
            : base(unit)
        { }

        public override ISpell GenerateAttack()
        {
            ISpell spell = new Stomp(base.Unit.AttackPoints);

            base.TakeEnergy(spell);
            base.Unit.AttackPoints += 5;

            return spell;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            List<IUnit> targets = new List<IUnit>();

            targets.AddRange(candidateTargets);

            if (base.Unit.HealthPoints <= 150)
            {
                targets = targets.Take(1).ToList();
            }

            return targets;
        }
    }
}
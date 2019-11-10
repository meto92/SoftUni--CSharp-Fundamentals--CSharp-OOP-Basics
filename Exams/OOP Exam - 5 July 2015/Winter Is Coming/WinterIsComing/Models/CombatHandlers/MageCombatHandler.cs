using System.Linq;
using System.Collections.Generic;

using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class MageCombatHandler : CombatHandler, ICombatHandler
    {
        private ISpell prevSpell;

        public MageCombatHandler(IUnit unit) 
            : base(unit)
        {
            this.prevSpell = new Blizzard(0);
        }

        public override ISpell GenerateAttack()
        {
            ISpell spell = null;

            if (this.prevSpell.GetType() == typeof(FireBreath))
            {
                spell = new Blizzard(2 * base.Unit.AttackPoints);
            }
            else
            {
                spell = new FireBreath(base.Unit.AttackPoints);
            }

            base.TakeEnergy(spell);

            prevSpell = spell;

            return spell;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            IEnumerable<IUnit> targets = candidateTargets
                .OrderByDescending(target => target.HealthPoints)
                .ThenBy(target => target.Name)
                .Take(3);

            return targets;
        }
    }
}
using System.Collections.Generic;

using WinterIsComing.Contracts;

namespace WinterIsComing.Core
{
    public class HealingUnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit unit in units)
            {
                unit.HealthPoints += 50;
            }
        }
    }
}
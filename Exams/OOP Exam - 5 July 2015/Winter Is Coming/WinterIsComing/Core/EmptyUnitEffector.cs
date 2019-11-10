namespace WinterIsComing.Core
{
    using Contracts;
    using System.Collections.Generic;

    public sealed class EmptyUnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit unit in units)
            {
            }
        }
    }
}
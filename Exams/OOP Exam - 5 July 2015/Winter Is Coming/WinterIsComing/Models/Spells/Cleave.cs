using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Cleave : AbstractSpell, ISpell
    {
        private const int CleaveEnergyCost = 15;

        public Cleave(int damage)
            : base(damage, CleaveEnergyCost)
        { }
    }
}
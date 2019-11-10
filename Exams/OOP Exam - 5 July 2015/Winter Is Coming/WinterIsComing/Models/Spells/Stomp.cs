using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Stomp : AbstractSpell, ISpell
    {
        private const int StompEnergyCost = 10;

        public Stomp(int damage)
            : base(damage, StompEnergyCost)
        { }
    }
}
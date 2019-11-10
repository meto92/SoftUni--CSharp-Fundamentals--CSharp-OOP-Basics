using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath : AbstractSpell, ISpell
    {
        private const int FireBreathEnergyCost = 30;

        public FireBreath(int damage) 
            : base(damage, FireBreathEnergyCost)
        { }
    }
}
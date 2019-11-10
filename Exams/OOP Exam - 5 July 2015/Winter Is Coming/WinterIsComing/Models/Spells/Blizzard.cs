using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Blizzard : AbstractSpell, ISpell
    {
        private const int BlizzardEnergyCost = 40;

        public Blizzard(int damage) 
            : base(damage, BlizzardEnergyCost)
        { }
    }
}
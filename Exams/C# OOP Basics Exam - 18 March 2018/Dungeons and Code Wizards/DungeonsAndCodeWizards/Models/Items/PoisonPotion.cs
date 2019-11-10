using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    [Item]
    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;
        private int PoisonPotionDamage = 20;

        public PoisonPotion()
            : base(PoisonPotionWeight)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= PoisonPotionDamage;
        }
    }
}
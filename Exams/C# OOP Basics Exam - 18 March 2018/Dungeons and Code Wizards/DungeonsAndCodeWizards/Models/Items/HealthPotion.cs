using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    [Item]
    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;
        private const int IncreasedHealthByHealthPotion = 20;

        public HealthPotion() 
            : base(HealthPotionWeight)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += IncreasedHealthByHealthPotion;
        }
    }
}
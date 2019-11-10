using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    [Item]
    public class ArmorRepairKit : Item
    {
        private const int ArmorRepairKitWeight = 10;

        public ArmorRepairKit() 
            : base(ArmorRepairKitWeight)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}
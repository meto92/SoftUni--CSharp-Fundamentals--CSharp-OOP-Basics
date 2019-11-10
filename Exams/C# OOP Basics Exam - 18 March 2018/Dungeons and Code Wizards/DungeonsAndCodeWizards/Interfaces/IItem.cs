using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IItem
    {
        int Weight
        {
            get;
        }

        string Name
        {
            get;
        }

        void AffectCharacter(Character character);
    }
}
using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    [Item]
    public abstract class Item : IItem
    {
        private int weight;

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }

        public string Name => this.GetType().Name;

        public virtual void AffectCharacter(Character character)
        {
            character.EnsureAlive();
        }
    }
}
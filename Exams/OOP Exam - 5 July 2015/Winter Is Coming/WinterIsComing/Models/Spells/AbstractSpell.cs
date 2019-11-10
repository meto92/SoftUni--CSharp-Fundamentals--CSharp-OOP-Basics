using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class AbstractSpell : ISpell
    {
        private int damage;
        private int energyCost;

        protected AbstractSpell(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage
        {
            get => this.damage;
            private set => this.damage = value;
        }

        public int EnergyCost
        {
            get => this.energyCost;
            private set => this.energyCost = value;
        }
    }
}
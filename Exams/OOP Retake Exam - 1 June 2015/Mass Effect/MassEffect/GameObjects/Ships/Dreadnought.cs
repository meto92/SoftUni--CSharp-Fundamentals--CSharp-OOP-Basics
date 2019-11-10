namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Dreadnought : Starship, IStarship
    {
        private const int DreadnoughtStartHealth = 200;
        private const int DreadnoughtStartShields = 300;
        private const int DreadnoughtStartDamage = 150;
        private const double DreadnoughtStartFuel = 700;

        public Dreadnought(string name, StarSystem location) 
            : base(
                  name,
                  DreadnoughtStartHealth,
                  DreadnoughtStartShields,
                  DreadnoughtStartDamage,
                  DreadnoughtStartFuel, 
                  location)
        { }

        public override IProjectile ProduceAttack()
        {
            return new Laser(base.Shields / 2 + base.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            base.Shields += 50;
            attack.Hit(this);
            base.Shields -= 50;
        }
    }
}
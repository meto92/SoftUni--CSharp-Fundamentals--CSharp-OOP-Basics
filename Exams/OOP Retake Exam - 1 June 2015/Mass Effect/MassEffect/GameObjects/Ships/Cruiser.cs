namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Cruiser : Starship, IStarship
    {
        private const int CruiserStartHealth = 100;
        private const int CruiserStartShields = 100;
        private const int CruiserStartDamage = 50;
        private const double CruiserStartFuel = 300;

        public Cruiser(string name, StarSystem location) 
            : base(
                  name,
                  CruiserStartHealth,
                  CruiserStartShields,
                  CruiserStartDamage,
                  CruiserStartFuel, 
                  location)
        { }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(base.Damage);
        }
    }
}
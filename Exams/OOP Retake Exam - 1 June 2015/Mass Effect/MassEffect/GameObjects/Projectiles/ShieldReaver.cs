namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class ShieldReaver : Projectile, IProjectile
    {
        public ShieldReaver(int damage) 
            : base(damage)
        { }

        public override void Hit(IStarship ship)
        {
            ship.Health -= base.Damage;
            ship.Shields -= 2 * base.Damage;
        }
    }
}
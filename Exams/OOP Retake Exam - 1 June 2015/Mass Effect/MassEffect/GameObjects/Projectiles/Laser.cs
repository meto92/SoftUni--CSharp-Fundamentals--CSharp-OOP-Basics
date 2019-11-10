namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class Laser : Projectile, IProjectile
    {
        public Laser(int damage) 
            : base(damage)
        { }

        public override void Hit(IStarship ship)
        {
            if (base.Damage <= ship.Shields)
            {
                ship.Shields -= base.Damage;
            }
            else
            {
                ship.Health -= base.Damage - ship.Shields;
                ship.Shields = 0;
            }
        }
    }
}
namespace MassEffect.GameObjects.Ships
{
    using System.Text;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Frigate : Starship, IStarship
    {
        private const int FrigateStartHealth = 60;
        private const int FrigateStartShields = 50;
        private const int FrigateStartDamage = 30;
        private const double FrigateStartFuel = 220;

        private int projectilesFiredCount;
        
        public Frigate(string name, StarSystem location) 
            : base(
                  name, 
                  FrigateStartHealth, 
                  FrigateStartShields, 
                  FrigateStartDamage, 
                  FrigateStartFuel, 
                  location)
        {
            this.projectilesFiredCount = 0;
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFiredCount++;

            return new ShieldReaver(base.Damage);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (base.Health == 0)
            {
                return sb.ToString().TrimEnd();
            }

            sb.Append($"-Projectiles fired: {projectilesFiredCount}");

            return sb.ToString();
        }
    }
}
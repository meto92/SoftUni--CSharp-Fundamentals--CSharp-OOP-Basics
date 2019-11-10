namespace MassEffect.Engine.Commands
{
    using MassEffect.Exceptions;
    using MassEffect.Interfaces;
    using System;
    using System.Linq;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        { }

        public override void Execute(string[] commandArgs)
        {
            string attackerShip = commandArgs[1];
            string targetShip = commandArgs[2];

            IStarship attacker = base.GameEngine
                .Starships
                .Where(ship => ship.Name == attackerShip)
                .First();
            IStarship target = base.GameEngine
                .Starships
                .Where(ship => ship.Name == targetShip)
                .First();

            if (attacker.Health == 0 || target.Health == 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }

            if (!attacker.Location.NeighbourStarSystems.ContainsKey(target.Location) &&
                attacker.Location != target.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            target.RespondToAttack(attacker.ProduceAttack());

            Console.WriteLine(string.Format(Messages.ShipAttacked, attackerShip, targetShip));

            if (target.Health == 0)
            {
                Console.WriteLine(string.Format(Messages.ShipDestroyed, targetShip));
            }
        }
    }
}
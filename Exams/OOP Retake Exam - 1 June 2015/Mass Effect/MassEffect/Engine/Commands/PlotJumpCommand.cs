namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        { }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string starSystemName = commandArgs[2];

            IStarship starShip = base.GameEngine
                .Starships
                .Where(ship => ship.Name == shipName)
                .First();

            if (starShip.Location.Name == starSystemName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, starSystemName));
            }

            StarSystem oldLocation = starShip.Location;
            StarSystem destination = base.GameEngine
                .Galaxy
                .GetStarSystemByName(starSystemName);

            base.GameEngine.Galaxy.TravelTo(starShip, destination);
            destination.Starships.Add(starShip);
            oldLocation.Starships.Remove(starShip);

            Console.WriteLine(
                string.Format(
                    Messages.ShipTraveled,
                    starShip.Name,
                    oldLocation.Name, 
                    destination.Name));
        }
    }
}
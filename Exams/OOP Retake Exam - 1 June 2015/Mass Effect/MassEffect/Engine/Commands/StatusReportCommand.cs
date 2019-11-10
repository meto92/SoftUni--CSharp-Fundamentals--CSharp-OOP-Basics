namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        { }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];

            IStarship starship = base.GameEngine
                .Starships
                .Where(ship => ship.Name == shipName)
                .FirstOrDefault();

            System.Console.WriteLine(starship);
        }
    }
}
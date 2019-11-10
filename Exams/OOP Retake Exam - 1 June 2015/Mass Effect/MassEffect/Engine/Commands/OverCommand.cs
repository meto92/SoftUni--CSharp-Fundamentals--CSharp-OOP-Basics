namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System;

    public class OverCommand : Command
    {
        public OverCommand(IGameEngine gameEngine)
            : base(gameEngine)
        { }

        public override void Execute(string[] commandArgs)
        {
            Environment.Exit(0);           
        }
    }
}
﻿namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public abstract class Command
    {
        public Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);
    }
}
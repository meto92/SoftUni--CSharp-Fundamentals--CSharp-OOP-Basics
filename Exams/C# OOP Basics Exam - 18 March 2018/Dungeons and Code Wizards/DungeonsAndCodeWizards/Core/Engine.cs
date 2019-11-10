using System;
using System.Linq;

using DungeonsAndCodeWizards.Core.Enums;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        private IInputReader inputReader;
        public IOutputWriter outputWriter;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
            this.inputReader = new ConsoleReader();
            this.outputWriter = new ConsoleWriter();
        }

        public void Run()
        {
            while (!this.dungeonMaster.IsGameOver())
            {
                string input = this.inputReader.ReadLine();

                if (input == null)
                {
                    break;
                }

                string[] commandArgs = input.Split();

                Command command = Enum.Parse<Command>(commandArgs[0]);

                string result = string.Empty;
                string[] args = commandArgs.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case Command.JoinParty:
                            result = this.dungeonMaster.JoinParty(args);
                            break;
                        case Command.AddItemToPool:
                            result = this.dungeonMaster.AddItemToPool(args);
                            break;
                        case Command.PickUpItem:
                            result = this.dungeonMaster.PickUpItem(args);
                            break;
                        case Command.UseItem:
                            result = this.dungeonMaster.UseItem(args);
                            break;
                        case Command.UseItemOn:
                            result = this.dungeonMaster.UseItemOn(args);
                            break;
                        case Command.GiveCharacterItem:
                            result = this.dungeonMaster.GiveCharacterItem(args);
                            break;
                        case Command.GetStats:
                            result = this.dungeonMaster.GetStats();
                            break;
                        case Command.Attack:
                            result = this.dungeonMaster.Attack(args);
                            break;
                        case Command.Heal:
                            result = this.dungeonMaster.Heal(args);
                            break;
                        case Command.EndTurn:
                            result = this.dungeonMaster.EndTurn(args);
                            break;
                        case Command.IsGameOver:
                            result = this.dungeonMaster.IsGameOver().ToString();
                            break;
                    }

                    if (result != string.Empty)
                    {
                        this.outputWriter.WriteLine(result); 
                    }
                }
                catch (ArgumentException aex)
                {
                    this.outputWriter.WriteLine($"Parameter Error: {aex.Message}");
                }
                catch (InvalidOperationException iopex)
                {
                    this.outputWriter.WriteLine($"Invalid Operation: {iopex.Message}");
                }
            }

            this.outputWriter.WriteLine("Final stats:");
            this.outputWriter.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
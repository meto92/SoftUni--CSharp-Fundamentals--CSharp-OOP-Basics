using MassEffect.Engine.Commands;

namespace MassEffect.Engine
{
    public class ExtendedCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            base.SeedCommands();

            base.commandsByName["system-report"] = new SystemReportCommand(base.Engine);
        }
    }
}
using WinterIsComing.Core.Commands;

namespace WinterIsComing.Core
{
    public class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            base.commandsByName["toggle-effector"] = new ToggleEffectorCommand(base.Engine);
        }
    }
}
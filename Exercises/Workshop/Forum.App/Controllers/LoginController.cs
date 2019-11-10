namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class LogInController : IController, IReadUserInfoController
    {
        private enum Command
        {
            ReadUsername,
            ReadPassword,
            LogIn,
            Back
        }

        private string username;
        private string password;
        private bool hasError;

        public LogInController()
        {
            this.ResetLogin();
        }
        
        public string Username
        {
            get => this.username;
            private set => this.username = value;
        }

        private void ResetLogin()
        {
            this.Username = string.Empty;
            this.password = string.Empty;
            this.hasError = false;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();

                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();

                    return MenuState.Login;
                case Command.LogIn:
                    bool loggedIn = UserService.TryLogInUser(this.Username, this.password);

                    if (loggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }

                    this.hasError = true;

                    return MenuState.Rerender;
                case Command.Back:
                    this.ResetLogin();

                    return MenuState.Back;
            }

            throw new System.InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.hasError, this.Username, this.password.Length);
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadPassword()
        {
            this.password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }
    }
}
namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;

	public class SignUpController : IController, IReadUserInfoController
	{
        public enum SignUpStatus
        {
            Success,
            DetailsError,
            UsernameTakenError
        }

        private enum Command
        {
            ReadUsername,
            ReadPassword,
            SignUp,
            Back
        }

		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        private string username;
        private string password;
        private string errorMessage;

        public string Username
        {
            get => this.username;
            private set => this.username = value;
        }

        private void ResetSignUp()
        {
            this.Username = string.Empty;
            this.password = string.Empty;
            this.errorMessage = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    SignUpStatus signup = UserService.TrySignUpUser(this.Username, this.password);
                    
                    switch (signup)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:
                            this.errorMessage = DETAILS_ERROR;
                            
                            return MenuState.Rerender;
                        case SignUpStatus.UsernameTakenError:
                            this.errorMessage = USERNAME_TAKEN_ERROR;
                            
                            return MenuState.Rerender;
                    }

                    return MenuState.Rerender;
                case Command.Back:
                    this.ResetSignUp();
                    return MenuState.Back;
            }

            throw new System.InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.errorMessage);
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
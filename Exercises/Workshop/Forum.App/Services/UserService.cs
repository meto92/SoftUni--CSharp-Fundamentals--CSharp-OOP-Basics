using System.Linq;

using Forum.Data;
using Forum.Models;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
        private const int UsernameMinLength = 3;
        private const int PasswordMinLength = 3;

        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users
                .Any(user => user.Username == username && user.Password == password);

            return userExists;
        }

        private static bool IsValid(string value, int minLength)
        {
            bool isValid =
                !string.IsNullOrWhiteSpace(value)
                && value.Length > minLength;

            return isValid;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool isUsernameValid = IsValid(username, UsernameMinLength);
            bool isPasswordValid = IsValid(password, PasswordMinLength);

            if (!isUsernameValid || !isPasswordValid)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExists = forumData.Users.Any(user => user.Username == username);

            if (!userAlreadyExists)
            {
                //int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                int userId = forumData.Users.Count + 1;

                User user = new User(userId, username, password);

                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();

            User user = forumData.Users.FirstOrDefault(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username, ForumData forumData)
        {
            User user = forumData.Users.FirstOrDefault(u => u.Username == username);

            return user;
        }
    }
}
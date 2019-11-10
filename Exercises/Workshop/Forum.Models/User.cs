using System.Collections.Generic;

namespace Forum.Models
{
    public class User : Identifiable
    {
        private string username;
        private string password;
        private List<int> postIds;

        public User(int id, string username, string password, IEnumerable<int> postIds = null)
            : base(id)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.postIds = new List<int>();
            this.postIds.AddRange(postIds ?? new List<int>());
        }

        public string Username
        {
            get => this.username;
            set => this.username = value;
        }

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        public ICollection<int> PostIds => this.postIds;
    }
}
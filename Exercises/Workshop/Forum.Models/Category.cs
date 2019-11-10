using System.Collections.Generic;

namespace Forum.Models
{
    public class Category : Identifiable
    {
        private string name;
        private List<int> postIds;

        public Category(int id, string name, IEnumerable<int> postIds = null)
            : base(id)
        {
            this.Name = name;
            this.postIds = new List<int>();
            this.postIds.AddRange(postIds ?? new List<int>());
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public ICollection<int> PostIds => this.postIds;
    }
}
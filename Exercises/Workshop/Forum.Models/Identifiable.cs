using Forum.Models.Interfaces;

namespace Forum.Models
{
    public abstract class Identifiable : IIdentifiable
    {
        private int id;

        protected Identifiable(int id)
        {
            this.Id = id;
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
    }
}
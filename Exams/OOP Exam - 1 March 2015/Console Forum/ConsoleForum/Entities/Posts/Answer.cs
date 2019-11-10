using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Answer : AbstractAnswer, IAnswer
    {
        public Answer(int id, string body, IUser author) 
            : base(id, body, author)
        { }
    }
}
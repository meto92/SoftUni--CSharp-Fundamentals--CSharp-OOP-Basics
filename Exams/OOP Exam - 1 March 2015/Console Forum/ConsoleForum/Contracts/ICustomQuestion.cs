namespace ConsoleForum.Contracts
{
    public interface ICustomQuestion : IQuestion
    {
        IAnswer BestAnswer { get; set; }
    }
}
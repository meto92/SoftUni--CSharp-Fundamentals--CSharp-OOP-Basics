namespace ConsoleForum
{
    using ConsoleForum.Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            bool addHeaders = false;

            IForum forum = new ExtendedForum(addHeaders);
            forum.Run();
        }
    }
}
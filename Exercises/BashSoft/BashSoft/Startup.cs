using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

class Startup
{
    static void Main(string[] args)
    {
        Tester tester = new Tester();
        IOManager ioManager = new IOManager();
        StudentsRepository repository = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

        CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repository, ioManager);
        InputReader reader = new InputReader(currentInterpreter);

        reader.StartReadingCommands();
    }
}
using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    public abstract class Command
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;
        private Match match;

        public Command(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Match = match;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        protected Tester Judge
        {
            get { return this.judge; }
        }

        protected StudentsRepository Repository
        {
            get { return this.repository; }
        }

        protected IOManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }

        protected Match Match
        {
            get
            {
                return match;
            }

            private set
            {
                match = value;
            }
        }

        public abstract void Execute();
    }
}
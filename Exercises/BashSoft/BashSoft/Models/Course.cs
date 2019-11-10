using System.Collections.Generic;

namespace BashSoft.Models
{
    public class Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, Student> studentsByName;

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get
            {
                return studentsByName;
            }
        }

        public void EnrollStudent(Student student)
        {
            if (this.StudentsByName.ContainsKey(student.Username))
            {
                throw new DuplicateEntryInStructureException(student.Username, this.Name);
            }

            this.studentsByName[student.Username] = student;
        }
    } 
}
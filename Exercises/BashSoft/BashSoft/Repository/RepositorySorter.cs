﻿using System.Linq;
using BashSoft.IO;
using System.Collections.Generic;

namespace BashSoft.Repository
{
    public class RepositorySorter
    {
        private void PrintStudents(Dictionary<string, double> sortedStudents)
        {
            foreach (KeyValuePair<string, double> pair in sortedStudents)
            {
                OutputWriter.PrintStudent(pair);
            }
        }

        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            Dictionary<string, double> sortedStudents = null;

            if (comparison == "ascending")
            {
                sortedStudents = studentsWithMarks.OrderBy(p => p.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            else
            {
                sortedStudents = studentsWithMarks.OrderByDescending(p => p.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            this.PrintStudents(sortedStudents);
        }
    } 
}
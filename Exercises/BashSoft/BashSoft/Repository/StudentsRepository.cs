﻿using System;
using System.IO;
using System.Linq;
using BashSoft.IO;
using BashSoft.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BashSoft.Repository
{
    public class StudentsRepository
    {
        private bool isDataInitialized;
        private const int MinYear = 2014;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        private bool IsYearValid(int year)
        {
            int currentYear = DateTime.Now.Year;

            return year >= MinYear && year <= currentYear;
        }

        private void ReadData(string fileName)
        {
            string path = $"{SessionData.currentPath}\\{fileName}";

            if (!File.Exists(path))
            {
                throw new InvalidPathException();
            }

            string[] allInputLines = File.ReadAllLines(path);

            foreach (string line in allInputLines)
            {
                Match match = Patterns.DbPattern.Match(line);

                if (!match.Success)
                {
                    continue;
                }

                int year = int.Parse(match.Groups["year"].Value);

                if (!IsYearValid(year))
                {
                    continue;
                }

                string courseName = match.Groups["courseName"].Value;
                string username = match.Groups["username"].Value;
                string scoresStr = match.Groups["scores"].Value;

                try
                {
                    int[] scores = scoresStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    if (scores.Any(x => x < 0 || x > 100))
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                    }

                    if (scores.Length > Course.NumberOfTasksOnExam)
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                        continue;
                    }

                    if (!this.courses.ContainsKey(courseName))
                    {
                        this.courses[courseName] = new Course(courseName);
                    }

                    if (!this.students.ContainsKey(username))
                    {
                        this.students[username] = new Student(username);
                    }

                    Course course = this.courses[courseName];
                    Student student = this.students[username];

                    student.EnrollInCourse(course);
                    student.SetMarksInCourse(courseName, scores);

                    course.EnrollStudent(student);
                }
                catch (FormatException fex)
                {
                    OutputWriter.DisplayException(fex.Message + $"at line : {line}");
                }
            }

            isDataInitialized = true;
            OutputWriter.WriteColoredMessageOnNewLine("Data read!");
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new DataAlreadyInitializedException();
            }

            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();

            OutputWriter.WriteMessageOnNewLine("Reading data...");
            ReadData(fileName);
        }

        public void UnloadDate()
        {
            if (!this.isDataInitialized)
            {
                throw new DataNotInitializedException();
            }

            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                bool courseExists = this.courses.ContainsKey(courseName);

                if (!courseExists)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }

                return courseExists;
            }

            throw new DataNotInitializedException();
        }

        private bool IsQueryForStudentPossiblе(string courseName, string studentUsername)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (!this.courses[courseName].StudentsByName.ContainsKey(studentUsername))
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
                    return false;
                }

                return true;
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossiblе(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");

                foreach (KeyValuePair<string, Student> studentMarksEntry
                    in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks =
                    this.courses[courseName]
                    .StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks =
                    this.courses[courseName]
                    .StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }
    } 
}
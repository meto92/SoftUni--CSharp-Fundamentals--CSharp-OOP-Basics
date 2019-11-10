using System;
using System.Linq;
using System.Collections.Generic;

namespace BashSoft.Models
{
    public class Student
    {
        private string username;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string username)
        {
            this.Username = username;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string Username
        {
            get
            {
                return username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                username = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get
            {
                return enrolledCourses;
            }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get
            {
                return marksByCourseName;
            }
        }

        public void EnrollInCourse(Course course)
        {
            if (this.EnrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.Username, course.Name);
            }

            this.enrolledCourses[course.Name] = course;
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() /
                (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.EnrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException(this.Username, courseName);
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName[courseName] = CalculateMark(scores);
        }
    } 
}
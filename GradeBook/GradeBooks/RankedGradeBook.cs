using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            int numberOfStudents;
            numberOfStudents = Students.Count;

            if (numberOfStudents < 5)
            {
                //throw new System.InvalidOperationException("Ranked grading requires at least five students with grades to properly calculate a student's overall grade.");
                Console.WriteLine("Ranked grading requires at least five students with grades to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            int numberOfStudents;
            numberOfStudents = Students.Count;

            if (numberOfStudents < 5)
            {
                //throw new System.InvalidOperationException("Ranked grading requires at least five students with grades to properly calculate a student's overall grade.");
                Console.WriteLine("Ranked grading requires at least five students with grades to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents;
            double minAverageGrade = 100;
            double maxAverageGrade = 0;
            double rankInterval;

            numberOfStudents = Students.Count;
            if (numberOfStudents < 5)
            {
                throw new System.InvalidOperationException("Ranked grading requires at least five students in the class.");
            }

            foreach (Student student in Students)
            {
                if (student.AverageGrade < minAverageGrade)
                {
                    minAverageGrade = student.AverageGrade;
                }

                if (student.AverageGrade > maxAverageGrade)
                {
                    maxAverageGrade = student.AverageGrade;
                }
            }

            rankInterval = (maxAverageGrade - minAverageGrade) / numberOfStudents;

            if ((maxAverageGrade - rankInterval) < averageGrade)
                return 'A';
            else if ((maxAverageGrade - rankInterval * 2) < averageGrade)
                return 'B';
            else if ((maxAverageGrade - rankInterval * 3) < averageGrade)
                return 'C';
            else if ((maxAverageGrade - rankInterval * 4) < averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}

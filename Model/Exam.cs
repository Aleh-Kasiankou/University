using System;

namespace University
{
    public class Exam
    {
        public Teacher Teacher { get; }
        public int PassingScore { get;}

        public Exam(Teacher teacher)
        {
            Teacher = teacher;
            PassingScore =Convert.ToInt32((teacher.TeachingLevel + teacher.StrictnessLevel) / 2 * 10);
        }
    }
}
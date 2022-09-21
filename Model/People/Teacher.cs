using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    public class Teacher : Person
    {
        public int TeachingLevel { get; set; }
        public int StrictnessLevel { get; set; }
        public University University { get; set; }
        public Subject Subject { get; set; }

        private Teacher(University university,Subject subject) : base() 
                                                         
        {
            int randomTeachingLevel = new Random().Next(1, 11);
            TeachingLevel = randomTeachingLevel;
            StrictnessLevel = new Random().Next(1, 11);
            University = university;
            Subject = subject;
        }

        public static Teacher CreateNew(University university, Subject subject) 
        {
            var newTeacher = new Teacher(university, subject);
            subject.Teacher = newTeacher;
            return newTeacher;
        }

        public void ConductAnExam() 
        {
            University.Exams.Add(new Exam(this));
        }


    }
}
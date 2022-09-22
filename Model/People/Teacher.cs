using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    public class Teacher : Person
    {
        public int TeachingLevel { get; set; }
        public int StrictnessLevel { get; set; }
        public Department Department { get; set; }
        public Subject Subject { get; set; }

        private Teacher(Department department,Subject subject) : base() 
                                                         
        {
            int randomTeachingLevel = new Random().Next(1, 11);
            TeachingLevel = randomTeachingLevel;
            StrictnessLevel = new Random().Next(1, 11);
            Department = department;
            Subject = subject;
        }

        public static Teacher CreateNew(Department department, Subject subject) 
        {
            var newTeacher = new Teacher(department, subject);
            subject.Teacher = newTeacher;
            return newTeacher;
        }

        public void ConductAnExam() 
        {
            Department.Exams.Add(new Exam(this));
        }


    }
}
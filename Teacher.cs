using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    public class Teacher : Person
    {
        public int TeachingLevel { get; set; }
        public Subject Subject { get; set; }

        private Teacher(Subject subject) : base() //parent constructor only requires name parameter
                                                         
        {
            int randomTeachingLevel = new Random().Next(0, 11);
            TeachingLevel = randomTeachingLevel;
            Subject = subject;
        }

        public static Teacher CreateNew(Subject subject) //Serves as a public constructor.
                                                                      //Needed to assign teacher to a subject
        {
            var newTeacher = new Teacher(subject);
            subject.Teacher = newTeacher;
            return newTeacher;
        }

        public void ConductAnExam() 
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
namespace University
{
    public class Teacher : Person
    {
        public int TeachingLevel { get; set; }
        public Subject Subject { get; set; }

        public Teacher(string name, int sex, Subject subject) : base(name, sex)
        {
            int randomTeachingLevel = new Random().Next(0, 11);
            TeachingLevel = randomTeachingLevel;
            Subject = subject;
        }
        public void ConductingAnExam()
        {

        }

    }
    }
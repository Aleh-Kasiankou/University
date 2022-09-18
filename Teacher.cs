using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    public class Teacher : Person
    {
        public int TeachingLevel { get; set; }
        public Subject Subject { get; set; } //switched type to class subject that will be used in the program

        public Teacher(string name, int sex, Subject subject) : base(name, sex)     // Will cause merge conflicts.
                                                                                    // Need to resolve them during merge. 
        {
            int randomTeachingLevel = new Random().Next(0, 11); 
            // the maximal value is not included in range, so changed 10 to 11
            TeachingLevel = randomTeachingLevel;
            Subject = subject;
        }

        public void ConductAnExam() //used infinitive form to denote non-continuous action
        {
        }
    }
}
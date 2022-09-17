using System;
using System.Collections.Generic;
using System.Text;
namespace University
{
    public class Teacher : Person
    {
        public int Teachinglevel { get; set; }
        public string Subject { get; set; }

        public Teacher(string name, int sex, string subject) : base(name, sex)
        {
            Random x = new Random();
            int teachinglevel = x.Next(0, 10);
            Teachinglevel = teachinglevel;
            Subject = subject;
        }
        public int TL1()
        {
            return Teachinglevel;
        }
        public void ConductingAnExam()
        {

        }

    }
    }
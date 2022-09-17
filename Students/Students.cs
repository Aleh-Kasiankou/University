using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
   public class Students 
    {
        public string NameStudents { get; set; }
        public int AgeStudents { get; set; }
        public bool AcademicPerformance { get; set; }
        public bool Sex { get; set; }
        public bool BoolIsExpelled { get; set; }
        public int Recklessness { get; set; }
        public int Interest { get; set; }

        public Students(string name, int age, bool sex, bool BE, bool AP, int Rk, int Ir)
        {
            NameStudents = name;
            AgeStudents = age;
            Sex = sex;
            BoolIsExpelled = BE;
            AcademicPerformance = AP;
            Recklessness = Rk;
            Interest = Ir;
        }
        


    }
}

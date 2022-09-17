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

        public Students(string name, int age, bool sex, bool AP, bool BE,int Reckless)
        {
            NameStudents = name;
            AgeStudents = age;
            Sex = sex;
            AcademicPerformance = AP;
            BoolIsExpelled = BE;


        }
    }
}

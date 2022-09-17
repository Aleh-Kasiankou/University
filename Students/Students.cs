using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
   public class Students
    {
        public string NameStudents { get; set; }
        public int AgeStudents { get; set; }
        public int AcademicPerformance { get; set; }
        public int Sex { get; set; }
        public bool BoolIsExpelled { get; set; }

        public Students(string name, int age, int sex, int AP, bool BE)
        {
            NameStudents = name;
            AgeStudents = age;
            Sex = sex;
            AcademicPerformance = AP;
            BoolIsExpelled = BE;


        }
    }
}

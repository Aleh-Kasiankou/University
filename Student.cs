using System;
using System.Collections.Generic;

namespace University
{
    public class Student : Person
    {
        public bool IsExpelled { get; set; } = false;
        private int RecklessnessLevel { get; set; }
        private Dictionary<Subject, int> AcademicPerformance { get; set; } = new Dictionary<Subject, int>();
        private Dictionary<Subject, bool> ExamPerformance { get; set; } = new Dictionary<Subject, bool>();

        public Student()
        {
            RecklessnessLevel = new Random().Next(1, 101);
        }

        public void AttendClasses(Subject subject)
        {
        }

        public void TakeExam() //accepts Exam exam. Removed for project to compile
        {
        }
    }
}
//before refactoring

// using System;
// using System.Collections.Generic;
// using System.Text;
//
// namespace Students
// {
//     public class Students           - the class name should be singular
//                                              since this is a class for one student
//     {
//         public string NameStudents { get; set; }              - adding 'Students' part is not necessary because Name
//                                                                       and Age will be associated with object of the Student class
//                                                                         and it will be clear who the property belongs to:
//                                                                             student.Age, student.Name
//
//         public int AgeStudents { get; set; }                   - the age is not used in calculations of Academic
//                                                                      and Exams performance or in other methods. It is not used.
//                                                                 (If you'd like to use it, lets add it later)
//
//         public bool AcademicPerformance { get; set; }          - bool type only contains true or false. We'd like to save Subject - Grade pair.
//                                                                      Dictionary will do the job.
//
//         public bool Sex { get; set; }                          - while bool could work for Sex, we will have to change
//                                                                  the type if students/teachers have a different self-identification            
//
//         public bool BoolIsExpelled { get; set; }               - could remove Bool from property name.
//                                                                  Pattern IsSomething gives a hint that the property
//                                                                  could be either true or false.
//
//         public int Recklessness { get; set; }                  - added Level to comply with naming of properties in other classes
//                                                                  (Teacher.TeachingLevel)
//
//         public int Interest { get; set; }                      - Interest depends on the teaching level, so the
//                                                                  duplicated functionality could be safely removed.
//
//         public Students(string name, int age, bool sex, bool BE, bool AP, int Rk, int Ir)  
//                                                            - some properties could have initial value instead of setting the value in constructor.
//                                                            - since the Student class is derived from Person, the base constructor should also be called
//         {
//             NameStudents = name;
//             AgeStudents = age;
//             Sex = sex;
//             BoolIsExpelled = BE;
//             AcademicPerformance = AP;
//             Recklessness = Rk;
//             Interest = Ir;
//         }
//
//
//
//     }
// }
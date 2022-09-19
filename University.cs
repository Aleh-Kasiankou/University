using System;
using System.Collections.Generic;

namespace University
{
    public class University
    {
        public string Name { get; set; }
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Student> Student { get; set; } = new List<Student>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public University(string name)
        {
            Name = name;
        }

        public void HireStaff(University university) 
        {
            int numberofsubject = 0;
            while (numberofsubject <= Subjects.Count)
            {
                var subject = new Subject(DataProvider.GenerateSubjectName(university));
                Subjects.Add(subject);
                numberofsubject++;

                for (int numberofstaff = 0; numberofstaff <= Subjects.Count; numberofstaff++)
                {
                    var teacher = Teacher.CreateNew(subject);
                    Staff.Add(teacher);
                }
            }            
                
                         
           
        }
        
        public void AdmitStudents()
        {
        }
        
        public void StartAcademicYear()
        {
        }

    }
}
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

        public void HireStaff(object university) 
        {
            int numberofstuff = Subjects.Count;
            for (; numberofstuff>0; numberofstuff--)
            {
                var subject = new Subject(DataProvider.GenerateSubjectName(university));
                Subjects.Add(subject);
                var teacher = Teacher.CreateNew(subject);
                Staff.Add(teacher);
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
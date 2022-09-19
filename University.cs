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

        public void HireStaff() //here we will create both subjects and teachers (potentially could create a
                                                                                    //new method for subjects)
        {
            List<Subject> Subjects  = new List<Subject>();
            int numberofstuff = Subjects.Count;
            for (int numberofstaff; numberofstuff>0; numberofstuff--)
            {
                
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
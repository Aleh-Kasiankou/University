using System;
using System.Collections.Generic;

namespace University
{
    public class University
    {
        public string Name { get; set; }
        public int StudentsCapacity { get; }
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public University(string name, int studentsNumber = 500)
        {
            Name = name;
            if (studentsNumber < 100 || studentsNumber > 1000)
            {
                throw new Exception(message:"Only 100-1000 can study at this univercity");
            }
            
            StudentsCapacity = studentsNumber;
        }

        public void HireStaff()
        {
        }

        public void AdmitStudents()
        {
            for (int studentsGenerated = 0; studentsGenerated < StudentsCapacity; studentsGenerated++)
            {
                var student = new Student();
                Students.Add(student);
            }
        }

        public void StartAcademicYear()
        {
        }
    }
}
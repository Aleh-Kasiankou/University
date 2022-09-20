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

        public void HireStaff() //method is not static, no need to pass university to it,
            //because the method will automatically interact with the class instance that called it
        {
            GenerateCurriculum();
            HireTeachers();
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

        private void GenerateCurriculum()
        {
            int numberOfSubjects = 0;
            while (numberOfSubjects < DataProvider.SubjectNames.Count)
                // while (numberofsubject <= Subjects.Count) Subjects.Count is 0 by default.
            {
                var subject = new Subject(DataProvider.GenerateSubjectName(this));
                //this is a keyword that returns the object owner of the method
                Subjects.Add(subject);
                numberOfSubjects++;
            }
        }

        private void HireTeachers()
        {
            foreach (var subject in Subjects)
            {
                var teacher = Teacher.CreateNew(subject);
                Staff.Add(teacher);
            }
        }
    }
}
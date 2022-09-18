using System;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = new University("BSUIR");
            university.HireStaff();
            university.AdmitStudents();
            university.StartAcademicYear();


            var student = new Student();
            university.Student.Add(student);
            var subject = new Subject(DataProvider.GenerateSubjectName(university));
            university.Subjects.Add(subject);
            var teacher = Teacher.CreateNew(subject);
            university.Staff.Add(teacher);
        }
    }
}
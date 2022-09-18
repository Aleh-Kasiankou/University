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

        }
    }
}
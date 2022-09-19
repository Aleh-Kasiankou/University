using System.Collections.Generic;

namespace University
{
    public class University
    {
        public string Name { get; set; }
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Student> Student { get; set; } = new List<Student>();
        public List<Subject> Subject { get; set; } = new List<Subject>();

        public University(string name)
        {
            Name = name;
        }

        public void HireStaff()
        {
        }
        
        public void AdmitStudents()
        {
            Random rnd = new Random(10);
            int randomNumberOfStudents = rnd.Next(10, 1000);
            NumberOfStudents = randomNumberOfStudents;

            var AddStudent = new AddStudent(student);
            student.Student = AddStudent;
            return AddStudent;
        }
        
        public void StartAcademicYear()
        {
        }

    }
}
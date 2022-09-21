using System.Collections.Generic;

namespace University
{
    public class Department
    {
        public string Name { get; set; }
        public University University { get; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Student> Students { get; set; } = new List<Student>();

        public Department(University university)
        {
            Name = DataProvider.GenerateDepartmentName(university.Field);
        }
    }
}
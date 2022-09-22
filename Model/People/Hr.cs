using System.Linq;

namespace University
{
    public class Hr : IStaffMember
    {
        public University University { get; set; }

        public Hr(University university)
        {
            University = university;
        }

        public void Work()
        {
            foreach (var department in University.Departments)
            {
                foreach (var subject in department.Subjects) //add check if teacher is already hired
                {
                    if (department.Staff.Count(teacher => teacher.Subject == subject) == 0)
                    {
                        var teacher = Teacher.CreateNew(department, subject);
                        department.Staff.Add(teacher);
                    }
                }
            }
        }
    }
}
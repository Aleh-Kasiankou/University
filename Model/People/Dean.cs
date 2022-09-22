namespace University
{
    public class Dean : IStaffMember
    {
        public University University { get; set; }
        public Department Department { get; }

        public Dean(Department department)
        {
            Department = department;
            University = department.University;
        }

        public void Work()
        {
            int numberOfSubjects = Department.Subjects.Count;
            while (numberOfSubjects < NameGenerator.SubjectNames.Count)
            {
                var subject = new Subject(NameGenerator.GenerateSubjectName(Department));
                Department.Subjects.Add(subject);
                numberOfSubjects++;
            }
        }
    }
}
using System.Collections.Generic;

namespace University
{
    public class Group: IStructureElement
    {
        public string Name { get; set; }
        public int Year { get; private set; } = 1;
        public static int StudentsCapacity { get; } = 14;
        public University University { get; }
        public List<Exam> Exams { get; set; } = new List<Exam>(); //implement logic for exams
        public List<Student> Students { get; set; }
        public IStructureElement ParentStructureElement { get; }
        public List<IStructureElement> ChildStructureElements { get; set; } = null;
        private static int NameHash { get; set; } = 1;

        public Group(IStructureElement parentStructureElement, List<Student> students)
        {
            Name = UpdateName();
            University = parentStructureElement.University;
            Students = students;
        }

        private string UpdateName()
        {
            var groupNumber = Year * 100 + NameHash++;
            return $"Group {groupNumber.ToString()}";
        }

        public void MoveToNextYear()
        {
            Year += 1;
            Name = UpdateName();
        }

        public static void ResetNameHash()
        {
            NameHash = 1;
        }

    }
}
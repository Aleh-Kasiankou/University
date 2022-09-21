using System.Collections.Generic;

namespace University
{
    public interface IStructureElement
    {
        public string Name { get; set; }
        public University University { get; }
        public static int StudentsCapacity { get; }
        public List<Student> Students { get; set; }
        public IStructureElement ParentStructureElement { get; }
        public List<IStructureElement> ChildStructureElements { get; set; }

        public void RemoveStudents(List<Student> studentsToRemove)
        {
            foreach (var student in studentsToRemove)
            {
                if (Students.Contains(student))
                {
                    Students.Remove(student);
                    foreach (var childStructure in ChildStructureElements)
                    {
                        if (childStructure.Students.Contains(student))
                        {
                            childStructure.Students.Remove(student);
                        }
                    }
                }
            }
        }
    }
}
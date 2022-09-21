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
        
        
    }
}
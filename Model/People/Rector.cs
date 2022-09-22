using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public class Rector : IStaffMember
    {
        public University University { get; set; }

        public Rector(University university)
        {
            University = university;
        }

        public void Work()
        {
            var excludedStudents = new List<Student>();

            foreach (IStructureElement department in University.Departments)
            {
                foreach (var student in department.Students)
                {
                    if (student.IsToBeExpelled)
                    {
                        excludedStudents.Add(student);
                    }
                }
                
                department.RemoveStudents(excludedStudents);

                foreach (Group group in department.ChildStructureElements)
                {
                    group.MoveToNextYear();
                }
            }

            Console.WriteLine(excludedStudents.Count + " were excluded from the university"); //move to separate class
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public class University
    {
        public string Name { get; set; }
        public int StudentsCapacity { get; }
        public Field Field { get; set; }

        public List<Department> Departments { get; } = new List<Department>();
        public List<IStaffMember> Administration { get; } = new List<IStaffMember>();

        private University(string name, int studentsNumber = 500)
        {
            Name = name;

            if (studentsNumber < 100 || studentsNumber > 1000)
            {
                throw new Exception(message: "Only 100-1000 can study at this university");
            }

            StudentsCapacity = studentsNumber;

            Field = (Field)new Random().Next(Enum.GetNames(typeof(Field)).Length);
        }

        public static University CreateNew(string name, int studentsNumber = 500)
        {
            var university = new University(name, studentsNumber);
            university.Administration.Add(new Hr(university));
            university.Administration.Add(new Rector(university));
            return university;
        }

        private void PrepareForYear()

        {
            GenerateDepartments();
            var hrSpecialist = Administration.First(specialist => specialist is Hr);
            hrSpecialist.Work();
            AdmitStudents();
        }


        private void AdmitStudents()
        {
            foreach (var department in Departments)
            {
                int optimalStudentsCount;
                if (Equals(department, Departments.Last()))
                {
                    optimalStudentsCount = StudentsCapacity -
                                           (from dep in Departments select dep.Students.Count).Sum();
                }

                else
                {
                    optimalStudentsCount = (StudentsCapacity / Departments.Count);
                }

                while (department.Students.Count != optimalStudentsCount)
                {
                    var student = new Student();
                    department.Students.Add(student);
                }
            }
        }

        public void OperateOneYear()
        {
            PrepareForYear();
            foreach (var department in Departments)
            {
                department.OperateOneYear();
            }
            FinishYear();
        }

        private void FinishYear()
        {
            var rector = Administration.First(specialist => specialist is Rector);
            rector.Work();
        }

        private void GenerateDepartments()
        {
            var optimalNumberOfDeps = (int)Math.Ceiling(StudentsCapacity / 200d);
            while (Departments.Count < optimalNumberOfDeps)
            {
                var name = NameGenerator.GenerateDepartmentName(this, out var maxDepartments);
                if (optimalNumberOfDeps > maxDepartments)
                {
                    optimalNumberOfDeps = maxDepartments;
                }

                Departments.Add(Department.CreateNew(this, name));
            }
        }
        
    }
}
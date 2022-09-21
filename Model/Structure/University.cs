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

        public University(string name, int studentsNumber = 500)
        {
            Name = name;

            if (studentsNumber < 100 || studentsNumber > 1000)
            {
                throw new Exception(message: "Only 100-1000 can study at this university");
            }

            StudentsCapacity = studentsNumber;

            Field = (Field)new Random().Next(Enum.GetNames(typeof(Field)).Length);
        }

        private void HireStaff() //why calling another method? Encapsulation?

        {
            HireTeachers();
        }


        private void AdmitStudents()
        {
            foreach (var department in Departments)
            {
                for (int studentsGenerated = 0; studentsGenerated < department.StudentsCapacity; studentsGenerated++)
                {
                    var student = new Student();
                    department.Students.Add(student);
                } 
            }
            
        }

        public void OperateOneYear()
        {
            GenerateDepartments();
            HireStaff();
            AdmitStudents();
            foreach (var department in Departments)
            {
                department.OperateOneYear();
            }
        }

        public void ExcludeStudents()
        {
            var excludedStudents = new List<Student>();

            foreach (var department in Departments)
            {
                foreach (var student in department.Students)
                {
                    if (student.IsToBeExpelled)
                    {
                        excludedStudents.Add(student);
                    }
                }

                department.Students = (from student in department.Students where !student.IsToBeExpelled select student)
                    .ToList();
            }


            Console.WriteLine(excludedStudents.Count + " were excluded from the university");
        }

        private void GenerateDepartments()
        {
            var optimalNumberOfDeps = (int)Math.Ceiling(StudentsCapacity / 200d);
            while (Departments.Count < optimalNumberOfDeps)
            {
                int optimalStudentsCount;
                if (Departments.Count == optimalNumberOfDeps - 1)
                {
                    optimalStudentsCount = StudentsCapacity -
                                           (from department in Departments select department.StudentsCapacity).Sum();
                }

                else
                {
                    optimalStudentsCount = (StudentsCapacity / optimalNumberOfDeps);
                }

                
                Departments.Add(new Department(this, optimalStudentsCount ));
            }
        }

        

        private void HireTeachers()
        {
            foreach (var department in Departments)
            {
                foreach (var subject in department.Subjects) //add check if teacher is already hired
                {
                    var teacher = Teacher.CreateNew(department, subject);
                    department.Staff.Add(teacher);
                }
                
            }
            
        }
    }
}
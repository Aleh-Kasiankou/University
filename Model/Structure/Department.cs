using System.Collections.Generic;
using System.Linq;

namespace University
{
    public class Department : IStructureElement
    {
        public string Name { get; set; }
        public University University { get; }
        public static int StudentsCapacity { get; } = 200;
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Exam> Exams { get; set; } = new List<Exam>();
        public List<Student> Students { get; set; } = new List<Student>();

        public IStructureElement ParentStructureElement { get; } = null;
        public List<IStructureElement> ChildStructureElements { get; set; } = new List<IStructureElement>();

        private Department(University university, string name)
        {
            University = university;
            Name = name;
        }

        public static Department CreateNew(University university, string name)
        {
            var department = new Department(university, name);
            var dean = new Dean(department);
            university.Administration.Add(dean);
            dean.Work();
            return department;
        }

        public void OperateOneYear()
        {
            DivideStudentsToGroups();
            foreach (var student in Students)
            {
                foreach (var subject in Subjects)
                {
                    student.StudySubject(subject);
                }
            }

            foreach (var subject in Subjects)
            {
                subject.Teacher.ConductAnExam();
            }

            foreach (var student in Students)
            {
                foreach (var exam in Exams)
                {
                    student.TakeExam(exam);
                    int reexaminationAttempt = 1;
                    while (student.ExamPerformance[exam.Teacher.Subject] == false && reexaminationAttempt <= 2)
                    {
                        student.RetakeAnExam(exam, reexaminationAttempt);
                        if (reexaminationAttempt == 2 && !student.ExamPerformance[exam.Teacher.Subject])
                        {
                            student.IsToBeExpelled = true;
                            
                        }

                        reexaminationAttempt++;
                    }
                }
            }
        }


        private void DivideStudentsToGroups()
        {
            while (Students.Count(student => student.Group is null) > 0)
            {
                var groupStudents = new List<Student>();
                var addedStudents = new List<Student>();
                while (Students.Count(student => student.Group is null) > addedStudents.Count &&
                       groupStudents.Count < Group.StudentsCapacity)
                {
                    var student = Students.First(student => student.Group is null && !addedStudents.Contains(student));
                    groupStudents.Add(student);
                    addedStudents.Add(student);
                }

                var group = new Group(this, groupStudents);
                foreach (var student in group.Students)
                {
                    student.Group = group;
                }

                ChildStructureElements.Add(group);
            }

            Group.ResetNameHash();
        }
    }
}
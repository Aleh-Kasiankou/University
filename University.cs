using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace University
{
    public class University
    {
        public string Name { get; set; }

        private int _capacityStudents;

        public int CapacityStudents
        {
            get { return _capacityStudents; }
            set
            {
                if (!(value >= 100 && value <= 1000))
                {
                    throw new Exception(message: "The number of students is not allowed. " +
                                                 "Please use values in range 100 - 1000");
                }

                _capacityStudents = value;
            }
        }

        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public University(string name, int capacityStudents = 500)
        {
            Name = name;
            CapacityStudents = capacityStudents;
        }

        public void HireStaff() //add support for many to one teacher - subject relation
        {
            while (true)
            {
                var subject = new Subject(DataProvider.GenerateSubjectName(this, out var generationFinished));
                Subjects.Add(subject);
                if (generationFinished)
                {
                    break;
                }
            }

            foreach (var subject in Subjects)
            {
                var teacher = Teacher.CreateNew(this,subject);
                Staff.Add(teacher);
            }
        }


        public void AdmitStudents()
        {
            while (Students.Count < CapacityStudents)
            {
                var student = new Student();
                Students.Add(student);
            }
        }

        public void StartAcademicYear()
        {
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
                    student.TakeAnExam(exam);
                    for (int reexaminationAttempt = 1; reexaminationAttempt < 3; reexaminationAttempt++)
                    {
                        student.RetakeAnExam(exam, reexaminationAttempt);
                        if (reexaminationAttempt == 2 && !student.ExamPerformance[exam.Teacher.Subject])
                        {
                            student.IsToBeExpelled = true;
                        }
                    }
                }
            }
        }

        public void ExcludeStudents()
        {
            var excludedStudents = new List<Student>();
            
            foreach (var student in Students)
            {
                if (student.IsToBeExpelled)
                {
                    excludedStudents.Add(student);
                }
            }

            Students = (from student in Students where !student.IsToBeExpelled select student).ToList();
            
            Console.WriteLine(excludedStudents.Count + " were excluded from the university");
        }
    }
}
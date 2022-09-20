using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public class University
    {
        public string Name { get; set; }

        public int StudentsCapacity { get; }
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public University(string name, int studentsNumber = 500)
        {
            Name = name;
            if (studentsNumber < 100 || studentsNumber > 1000)
            {
                throw new Exception(message:"Only 100-1000 can study at this univercity");
            }
            
            StudentsCapacity = studentsNumber;
        }

        public void HireStaff()
            
        {
            GenerateCurriculum();
            HireTeachers();
        }


        public void AdmitStudents()
        {
            for (int studentsGenerated = 0; studentsGenerated < StudentsCapacity; studentsGenerated++)
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
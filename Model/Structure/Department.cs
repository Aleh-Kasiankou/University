using System.Collections.Generic;

namespace University
{
    public class Department
    {
        public string Name { get; set; }
        public University University { get; }
        public int StudentsCapacity { get; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Teacher> Staff { get; set; } = new List<Teacher>();
        public List<Exam> Exams { get; set; } = new List<Exam>();
        public List<Student> Students { get; set; } = new List<Student>();

        public Department(University university, int studentsCapacity)
        {
            University = university;
            StudentsCapacity = studentsCapacity;
            Name = NameGenerator.GenerateDepartmentName(university.Field);
            GenerateCurriculum();
        }

        public void OperateOneYear()
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
                    student.TakeExam(exam);
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
        
        private void GenerateCurriculum()
        {
            int numberOfSubjects = 0;
            while (numberOfSubjects < NameGenerator.SubjectNames.Count)
                // while (numberofsubject <= Subjects.Count) Subjects.Count is 0 by default.
            {
                var subject = new Subject(NameGenerator.GenerateSubjectName(this));
                //this is a keyword that returns the object owner of the method
                Subjects.Add(subject);
                numberOfSubjects++;
            }
        }
    }
}
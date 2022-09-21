using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public class Student : Person
    {
        public bool IsToBeExpelled { get; set; } = false;
        private int RecklessnessLevel { get; set; }

        public Group Group { get; set; } = null;
        private Dictionary<Subject, int> AcademicPerformance { get; } = new Dictionary<Subject, int>();
        public Dictionary<Subject, bool> ExamPerformance { get; } = new Dictionary<Subject, bool>();

        public Student()
        {
            RecklessnessLevel = new Random().Next(1, 81); //totally crazy students are not likely to be admitted 
        }
        
        public void StudySubject(Subject subject)
        {
            var missesIndex = (subject.Teacher.TeachingLevel * 10 - RecklessnessLevel) / 2;

            AcademicPerformance[subject] = 50 + missesIndex;
        }

        public void TakeExam(Exam exam)
        {
            ExamPerformance[exam.Teacher.Subject] = AcademicPerformance[exam.Teacher.Subject] >= exam.PassingScore;
        }

        public void RetakeAnExam(Exam exam, int attempt)
        {
            PrepareForReexamination(exam, attempt);
            TakeExam(exam);
        }

        private void PrepareForReexamination(Exam exam, int attempt)
        {
            int failedExamsNumber = (from subject in ExamPerformance
                where !subject.Value
                select subject).Count();
            RecklessnessLevel -= attempt * (int) Math.Floor(RecklessnessLevel * 0.1) + failedExamsNumber;
            StudySubject(exam.Teacher.Subject);
        }
    }
}
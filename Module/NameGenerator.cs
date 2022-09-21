using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public static class NameGenerator
    {
        private static Dictionary<Sex, List<string>> HumanNames { get; } = new Dictionary<Sex, List<string>>()
        {
            {
                Sex.Female, new List<string>()
                {
                    "Annie", "Eliza", "Betty", "Valeria",
                    "Anastasia", "Katherine", "Josephine",
                    "Darya", "Eugenia"
                }
            },

            {
                Sex.Male, new List<string>()
                {
                    "Nikolas", "Andrew", "Jack", "John",
                    "Ivan", "Donald", "Bill", "Percival", "Adam"
                }
            },
        };

        public static List<string> SubjectNames { get; } = new List<string>()
            { "Math", "Foreign Language", "International Law", "Science", "PE", "Debates" };

        private static Dictionary<Field, List<string>> DepartmentNames { get; } = new Dictionary<Field, List<string>>()
        {
            {
                Field.Architecture,
                new List<string>()
                    { "Landscape Architecture", "Urban Planning", "Industrial Design", "Lighting Architecture" }
            },
            {
                Field.Communication,
                new List<string>() { "Translation", "Teaching", "Psychology", "Intercultural Communication" }
            },
            { Field.Law, new List<string>() { "Human Rights", "International Law", "Internal Law" } },
            {
                Field.Technology,
                new List<string>()
                    { "Computer Science", "Physics & Astronomy", "Molecular Life Sciences", "Biology & Chemistry" }
            },
            {
                Field.HealthCare,
                new List<string>()
                    { "Physiology", "Pharmacology", "Immunobiology", "Cellular and Molecular Medicine" }
            },
        };

        public static string GeneratePersonName(Sex sex)
        {
            var randomNameIndex = new Random().Next(HumanNames[sex].Count);
            return HumanNames[sex][randomNameIndex];
        }

        public static string GenerateSubjectName(Department department)
        {
            var usedSubjectNames = new List<string>();

            foreach (var subject in department.Subjects)
            {
                usedSubjectNames.Add(subject.Name);
            }

            return SubjectNames.First(name => !usedSubjectNames.Contains(name));
        }

        public static string GenerateDepartmentName(University university, out int maxdepartments)
        {
            var usedDepartmentNames = new List<string>();

            foreach (var department in university.Departments)
            {
                usedDepartmentNames.Add(department.Name);
            }
            var field = university.Field;
            maxdepartments = DepartmentNames[field].Count;
            
            return DepartmentNames[field].First(name => !usedDepartmentNames.Contains(name));
        }
    }
}
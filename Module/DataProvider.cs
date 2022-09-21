using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public static class DataProvider
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

        public static string GeneratePersonName(Sex sex)
        {
            var randomNameIndex = new Random().Next(HumanNames[sex].Count);
            return HumanNames[sex][randomNameIndex];
        }

        public static string GenerateSubjectName(University university)
        {
            var usedSubjectNames = new List<string>();

            foreach (var subject in university.Subjects)
            {
                usedSubjectNames.Add(subject.Name);
            }

            return SubjectNames.First(name => !usedSubjectNames.Contains(name));
        }

        public static string GenerateDepartmentName(Field field)
        {
            return "Not Implemented";
        }
    }
}
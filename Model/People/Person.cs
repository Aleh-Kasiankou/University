using System;

namespace University
{
    public abstract class Person
    {
        public string Name { get; }
        public Sex Sex { get; }
        

        public Person()
        {
            Sex = (Sex) new Random().Next(0,2);
            Name = NameGenerator.GeneratePersonName(Sex);
        }
    }
    
    public enum Sex{
        Male,
        Female
    }
    
}
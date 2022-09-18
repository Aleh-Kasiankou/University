using System;

namespace University
{
    public abstract class Person
    {
        public string Name { get; }
        public Sex Sex { get; }
        

        public Person(string name)
        {
            Name = name;
            Sex = (Sex) new Random().Next(0,2);
        }
    }
    
    public enum Sex{
        Male,
        Female
    }
    
}
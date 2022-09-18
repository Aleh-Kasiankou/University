using System;

namespace University
{
    public abstract class Person
    {
        public string Name { get; }
        public Sex Sex { get; }
        

        public Person(string name, int sex)
        {
            Name = name;
            Sex = (Sex) new Random().Next(0,2);
            sex = (int)Convert.ToUInt32(Sex);
        }
    }
    
    public enum Sex{
        Male,
        Female
    }
    
}
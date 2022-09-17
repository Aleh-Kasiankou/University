namespace University
{
    public abstract class Person
    {
        public string Name { get; }
        public int Sex { get; }

        public Person(string name, int sex)
        {
            Name = name;
            Sex = sex;
        }
    }
}
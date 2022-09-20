namespace University
{
    public class Subject
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }

        public Subject(string name)
        {
            Name = name;
        }
        
    }
}
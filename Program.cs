namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = new University("Whatever");
            university.OperateOneYear();
            university.ExcludeStudents();
        }
    }
}
namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = new University("BSUIR");
            university.OperateOneYear();
            university.ExcludeStudents();
        }
    }
}
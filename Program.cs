namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = University.CreateNew("Whatever");
            university.OperateOneYear();
        }
    }
}
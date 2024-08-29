namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "August 16, 2024";
            DateTime date = DateTime.Parse(input);
            string output = date.ToString("yyyy/MM/dd");
            Console.WriteLine("Hello, World!");
        }
    }
}
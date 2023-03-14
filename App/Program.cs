using GeomertyLibrary;

namespace Mindbox {
    class Program {
        static void Main(string[] args) {
            GeomertyLibrary.Circle circle = new GeomertyLibrary.Circle() { Radius = 10d };
            Console.WriteLine($"area = {circle.GetArea()}");

            string str = args.Aggregate("", (res, val) => res + $"{val.Trim(' ')} ").TrimEnd(' ');
            Console.WriteLine($"args = {str}");
        }
    }
}
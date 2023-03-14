using Geo = GeomertyLibrary;

namespace Mindbox {
    class Program {
        static void Main(string[] args) {
            Geo.Circle circle = new Geo.Circle(10d);
            Console.WriteLine($"area = {Math.Round(circle.CalculateArea(), 4)}");

            string str = args.Aggregate("", (res, val) => res + $"{val.Trim(' ')} ").TrimEnd(' ');
            Console.WriteLine($"args = {str}");

            Geo.Triangle triangle = new Geo.Triangle(2d, 2.828427d, 2d);
            Console.WriteLine($"area; = {Math.Round(triangle.CalculateArea(), 4)}");
            Console.WriteLine($"IsRightAngle; = {triangle.IsRightAngle}");
        }
    }
}
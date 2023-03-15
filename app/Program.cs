using Geo = GeomertyLibrary;
using System.CommandLine;

namespace Mindbox;

enum ShapeTypes {
    Circle, Triangle
}



class Program {

    static async Task<int> Main(string[] args) {

        var rootCommand = new RootCommand("Calculate shape geometry") {
            BuildCircleCmd(),
            BuildTrianglemd()
        };

        return await rootCommand.InvokeAsync(args);
    }

    static Command BuildCircleCmd() {
        var circleOption = new Option<double?>(aliases: new string[] { "--radius", "-r" },
            description: "Circle radius",
            parseArgument: result => {
                double radius = 0d;

                if (result.Tokens.Count() == 0 || !Double.TryParse(result.Tokens.First().Value, out radius)) {
                    result.ErrorMessage = "Invalid radius value";
                    return null;
                }

                return radius;

            }) { IsRequired = true };

        var circleCommand = new Command("circle", "Calculate circle geometry") {
            circleOption
        };

        circleCommand.SetHandler((ctx) => {
            double radius = ctx.GetValueOrDefault();
            Geo.Circle circle = new Geo.Circle(radius);
            Console.WriteLine($"area = {Math.Round(circle.CalculateArea(), 4)}");
        }, circleOption);

        return circleCommand;
    }

    static Command BuildTrianglemd() {
        var triangleOption = new Option<double[]>(aliases: new string[] { "--sides", "-s" },
            description: "Triangle sides",
            parseArgument: result => {
                double[] sides = new[] { 0d, 0d, 0d };

                if (result.Tokens.Count() != 3) {
                    result.ErrorMessage = "Invalid sides value";
                    return sides;
                }

                for (int i = 0; i < sides.Length; i++) {
                    Double.TryParse(result.Tokens.ElementAt(i).Value, out sides[i]);
                }

                return sides;

            }) { IsRequired = true, AllowMultipleArgumentsPerToken = true };

        var triangleCommand = new Command("triangle", "Calculate triangle geometry") {
            triangleOption
        };

        triangleCommand.SetHandler((ctx) => {
            double[] sides = ctx;
            Geo.Triangle triangle = new Geo.Triangle(sides[0], sides[1], sides[2]);
            Console.WriteLine($"area; = {Math.Round(triangle.CalculateArea(), 4)}");
            Console.WriteLine($"IsRightAngle; = {triangle.IsRightAngle}");
        }, triangleOption);

        return triangleCommand;
    }
}

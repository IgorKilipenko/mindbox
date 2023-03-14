using System.Diagnostics;
namespace GeomertyLibrary;

public class Triangle : Shape {
    public Triangle(double side1, double side2, double side3) {
        Sides = new[] { side1, side2, side3 };
    }

    public double[] Sides {
        get => _sides;
        protected set {
            Debug.Assert(_sides.Length == value.Length);
            _CheckSides(value);

            value.CopyTo(_sides, 0);
        }
    }

    public override double CalculateArea() {
        _CheckSides(_sides);

        double sp = Sides.Sum(x => Math.Abs(x)) / 2d;
        return Math.Sqrt(Sides.Aggregate(sp, (res, side) => res * (sp - Math.Abs(side))));
    }

    public bool IsRightAngle {
        get {
            _CheckSides(_sides);

            var orderedSides = Sides.Order();
            double hypotenuse = orderedSides.Last();
            if (hypotenuse == 0 || orderedSides.Count(x => x == hypotenuse) > 1) {
                return false;
            }

            double expectedHypotenuse = Math.Sqrt(orderedSides.SkipLast(1).Aggregate(0d, (res, x) => res + Math.Pow(x, 2)));
            return Math.Abs(expectedHypotenuse - hypotenuse) <= Shape.Tolerance;
        }
    }

    private void _CheckSides(double[] sides) {
        var orderedSides = sides.Order();
        var minSideLength = orderedSides.First();
        var maxideLength = orderedSides.Last();

        if (Math.Abs(minSideLength) <= Shape.Tolerance || orderedSides.SkipLast(1).Sum() <= maxideLength) {
            throw new ArgumentException("The sum of two side lengths has to exceed the length of the third side");
        }
    }

    private double[] _sides = new double[3];
}
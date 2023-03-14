namespace GeomertyLibrary;

public class Circle : Shape {

    public Circle(double radius) {
        Radius = radius;
    }

    public double Radius { get => _radius; set => _radius = Math.Abs(value); }

    public override double CalculateArea() {
        return Math.Pow(Radius, 2) * Math.PI;
    }

    private double _radius;
}
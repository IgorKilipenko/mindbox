namespace GeomertyLibrary;

public interface IShape {
    public double CalculateArea();
}

public abstract class Shape : IShape {
    public abstract double CalculateArea();

    public static double Tolerance { get; } = Math.Pow(10d,-6);
}
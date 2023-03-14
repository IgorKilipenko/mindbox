using Geo = GeomertyLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class GeomertyLibraryUnitTest {
    [TestMethod]
    public void TestCircleArea() {
        Geo.Circle circle = new Geo.Circle(2d);
        const double expected = Math.PI * 4d;
        double area = circle.CalculateArea();

        Assert.AreEqual(expected, area, Geo.Shape.Tolerance,
            $"Expected for radius '{circle.Radius}': {expected}; Actual: {area}");
    }

    [TestMethod]
    public void TestTriangleInvalidSide() {
        string failedMsg = "Must throw ArgumentException";

        Assert.ThrowsException<ArgumentException>(() => new Geo.Triangle(2d, 0d, 4d), failedMsg);
        Assert.ThrowsException<ArgumentException>(() => new Geo.Triangle(2d, 3d, 6d), failedMsg);

        Geo.Triangle triangle = new Geo.Triangle(2d, 3d, 4d);
        triangle.Sides[2] = 6d;
        Assert.ThrowsException<ArgumentException>(() => triangle.CalculateArea(), failedMsg);
        Assert.ThrowsException<ArgumentException>(() => triangle.IsRightAngle, failedMsg);

        triangle.Sides[2] = 4d;
        triangle.Sides[1] = 0d;
        Assert.ThrowsException<ArgumentException>(() => triangle.CalculateArea(), failedMsg);
        Assert.ThrowsException<ArgumentException>(() => triangle.IsRightAngle, failedMsg);
    }

    [TestMethod]
    public void TestTriangleArea() {
        Geo.Triangle triangle = new Geo.Triangle(2d, 3d, 4d);
        const double expected = 2.9047375d;
        double area = triangle.CalculateArea();

        Assert.AreEqual(expected, area, Geo.Shape.Tolerance);
    }

    [TestMethod]
    public void TestTriangleRightAngle() {
        Geo.Triangle triangle = new Geo.Triangle(2d, 2.828427d, 2d);
        Assert.IsTrue(triangle.IsRightAngle);
    }
}
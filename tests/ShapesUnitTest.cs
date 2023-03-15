using Geo = GeomertyLibrary;

namespace Tests;

[TestClass]
public class CircleUnitTest {
    [TestMethod]
    public void TestArea() {
        Geo.Circle circle = new Geo.Circle(0d);
        double expected = 0d;
        double area = circle.CalculateArea();
        Assert.AreEqual(expected, area, Geo.Shape.Tolerance);

        circle.Radius = 2d;
        expected = Math.PI * Math.Pow(circle.Radius,2);
        area = circle.CalculateArea();
        Assert.AreEqual(expected, area, Geo.Shape.Tolerance);
    }
}

[TestClass]
public class TriangleUnitTest {
    [TestMethod]
    public void TestInvalidSide() {
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
    public void TestArea() {
        Geo.Triangle triangle = new Geo.Triangle(2d, 3d, 4d);
        const double expected = 2.9047375d;
        double area = triangle.CalculateArea();

        Assert.AreEqual(expected, area, Geo.Shape.Tolerance);
    }

    [TestMethod]
    public void TestRightAngle() {
        var test = (double angle, double width) => {
            double hypotenuse = 1d / Math.Cos(angle) * width;
            double heigth = Math.Tan(angle) * width;

            Geo.Triangle triangle = new Geo.Triangle(hypotenuse, heigth, width);
            Assert.IsTrue(triangle.IsRightAngle);
        };

        double angle = Math.PI / 2d;
        double width = 10d;

        while ((angle -= Math.PI / 180d) > Math.PI / 180d) {
            try {
                test(angle, width);
            } catch {
                Assert.Fail();
            }
        }
    }
}
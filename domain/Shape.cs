namespace Mindbox {
    interface IShape {
        public double GetArea();
    }

    class Circle : IShape {
        public double Radius { get; set; }

        public double GetArea() {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }
}
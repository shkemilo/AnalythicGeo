using System;

namespace AnalythicGeo
{
    /// <summary>
    /// Represents a point in a 2-dimensional plane.
    /// </summary>
    internal class Point : IVisualObject
    {
        public double X { get; set; }
        public double Y { get; set; }

        public string Label { get; set; }

        /// <summary>
        /// Default constructor which generates a point in the Origin.
        /// </summary>
        public Point()
        {
            X = 0;
            Y = 0;

            Label = "Origin";
        }

        /// <summary>
        /// Constructor which generates a point with custom coordinates and an optional label.
        /// </summary>
        public Point(double x, double y, string label = "Point")
        {
            X = x;
            Y = y;

            Label = label;
        }

        /// <summary>
        /// Calculates the distance between points.
        /// </summary>
        public double Distance(Point targetPoint)
        {
            return Math.Sqrt(Math.Pow(X - targetPoint.X, 2) + Math.Pow(Y - targetPoint.Y, 2));
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the human-readable string representation of a Point.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}({1}, {2})", Label, X, Y);
        }
    }
}
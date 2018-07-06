using System;

namespace AnalythicGeo
{
    /// <summary>
    /// Represents a Line in a 2-dimensional plane.
    /// </summary>
    internal class Line : IVisualObject
    {
        public double Slope { get; set; }
        public double YIntercept { get; set; }

        public string Label { get; set; }

        /// <summary>
        /// Constructor which creates a line based on its slope and Y-intercept values.
        /// </summary>
        public Line(double slope, double yintercept, string label = "Line")
        {
            Slope = slope;
            YIntercept = yintercept;

            Label = label;
        }

        /// <summary>
        /// Constructor which creates a line that passes through 2 Points.
        /// </summary>
        public Line(Point point0, Point point1) //TODO: solve X0 = X1 lines
        {
            Slope = (point1.Y - point0.Y) / (point1.X - point0.X);
            YIntercept = ((point1.X * point0.Y) - (point0.X * point1.Y)) / (point1.X - point0.X);
        }

        /// <summary>
        /// Returns the incline of a Line.
        /// </summary>
        /// <returns></returns>
        public double GetIncline()
        {
            return Math.Atan(Slope);
        }

        /// <summary>
        /// Returns whether a Point is contained within a Line.
        /// </summary>
        public bool IsPointContained(Point point)
        {
            return point.Y == ((point.X * Slope) + YIntercept);
        }

        /// <summary>
        /// Returns the angle between two lines.
        /// </summary>
        public double GetAngleBetweenLines(Line targetLine)
        {
            return Math.Atan(Math.Abs((Slope - targetLine.Slope) / (1 + Slope * targetLine.Slope)));
        }

        /// <summary>
        /// Returns the point which represents the intersection between two lines.
        /// </summary>
        public Point IntersectionPoint(Line targetLine)
        {
            double x = (targetLine.YIntercept - YIntercept) / (Slope - targetLine.Slope);
            double y = (Slope * x + YIntercept);

            return new Point(x, y, Label + targetLine.Label + "Intersection");
        }

        /// <summary>
        /// Returns whether two lines are parallel.
        /// </summary>
        public bool AreLinesParallel(Line targetLine)
        {
            return Slope == targetLine.Slope;
        }

        /// <summary>
        /// Returns whether two lines are perpendicular.
        /// </summary>
        public bool AreLinesPerpendicular(Line targetLine)
        {
            return Slope * targetLine.Slope == -1;
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
            return String.Format("Y = {0} * X + {1}", Slope, YIntercept);
        }
    }
}
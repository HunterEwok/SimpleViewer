using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Viewer.Shapes
{
    // Triangle shape implementation

    internal class TriangleShape : IShape
    {
        private Point A { get; }
        private Point B { get; }
        private Point C { get; }
        private bool IsFilled { get; }
        private Color Color { get; }

        public TriangleShape(RawShape rawShape)
        {
            A = Helper.ParsePoint(rawShape.A ?? string.Empty);
            B = Helper.ParsePoint(rawShape.B ?? string.Empty);
            C = Helper.ParsePoint(rawShape.C ?? string.Empty);
            IsFilled = rawShape.Filled ?? false;
            Color = Helper.ParseColor(rawShape.Color ?? string.Empty);
        }

        public UIElement Render(double scale, double centerX, double centerY)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection(
                    new[] { A, B, C }.Select(p => new System.Windows.Point(p.X, p.Y))),
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1,
                Fill = IsFilled ? new SolidColorBrush(Color) : Brushes.Transparent
            };

            for (int i = 0; i < polygon.Points.Count; i++)
            {
                polygon.Points[i] = 
                    new Point(
                        (polygon.Points[i].X) * scale + centerX,
                        (polygon.Points[i].Y) * scale + centerY);
            }
                
            return polygon;
        }

        public Rect GetBounds()
        {
            double minX = Math.Min(Math.Min(A.X, B.X), C.X);
            double maxX = Math.Max(Math.Max(A.X, B.X), C.X);
            double minY = Math.Min(Math.Min(A.Y, B.Y), C.Y);
            double maxY = Math.Max(Math.Max(A.Y, B.Y), C.Y);

            return new Rect(minY, minX, maxX, maxY);
        }
    }
}
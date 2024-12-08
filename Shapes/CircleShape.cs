using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Viewer.Shapes
{
    // Circle shape implementation
    internal class CircleShape : IShape
    {
        private Point Center { get; }
        private double Radius { get; }
        private bool IsFilled { get; }
        private Color Color { get; }

        public CircleShape(RawShape rawShape)
        {
            Center = Helper.ParsePoint(rawShape.Center ?? string.Empty);
            Radius = rawShape.Radius ?? 0;
            IsFilled = rawShape.Filled ?? false;
            Color = Helper.ParseColor(rawShape.Color ?? string.Empty);
        }

        public UIElement Render(double scale, double centerX, double centerY)
        {
            var ellipse = new Ellipse
            {
                Width = Radius * 2 * scale,
                Height = Radius * 2 * scale,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1,
                Fill = IsFilled ? new SolidColorBrush(Color) : Brushes.Transparent
            };

            Canvas.SetLeft(ellipse, (Center.X - Radius) * scale + centerX);
            Canvas.SetTop(ellipse, (Center.Y - Radius) * scale + centerY);

            return ellipse;
        }

        public Rect GetBounds()
        {
            double left = Center.X - Radius;
            double top = Center.Y - Radius;
            double wiidth = Radius * 2;
            double height = Radius * 2;

            return new Rect(left, top, wiidth, height);
        }
    }
}

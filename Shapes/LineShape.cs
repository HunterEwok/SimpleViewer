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
    // Line shape implementation

    internal class LineShape : IShape
    {
        private Point A { get; }
        private Point B { get; }
        private Color Color { get; }

        public LineShape(RawShape rawShape)
        {
            A = Helper.ParsePoint(rawShape.A ?? string.Empty);
            B = Helper.ParsePoint(rawShape.B ?? string.Empty);
            Color = Helper.ParseColor(rawShape.Color ?? string.Empty);
        }

        public Rect GetBounds() => new Rect(A, B);

        public UIElement Render(double scale, double centerX, double centerY)
        {
            var line = new Line
            {
                X1 = A.X * scale + centerX,
                Y1 = A.Y * scale + centerY,
                X2 = B.X * scale + centerX,
                Y2 = B.Y * scale + centerY,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };

            return line;
        }
    }
}

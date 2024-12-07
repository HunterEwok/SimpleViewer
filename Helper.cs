using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Viewer
{
    internal static class Helper
    {
        public static Point ParsePoint(string pointStr)
        {
            var parts = pointStr.Split(';').Select(double.Parse).ToArray();

            return new Point(parts[0], parts[1]);
        }

        public static Color ParseColor(string colorStr)
        {
            var parts = colorStr.Split(';').Select(byte.Parse).ToArray();

            return Color.FromArgb(parts[0], parts[1], parts[2], parts[3]);
        }

        // Calculates the scale to fit the shapes within the canvas
        public static double CalculateScale(
            IEnumerable<IShape> shapes, 
            double canvasWidth, 
            double canvasHeight)
        {
            var bounds = shapes.Aggregate(
                new Rect(0, 0, 0, 0),
                (rect, shape) => Rect.Union(rect, shape.GetBounds())
            );

            double scaleX = canvasWidth / bounds.Width;
            double scaleY = canvasHeight / bounds.Height;

            return Math.Min(scaleX, scaleY);
        }
    }
}

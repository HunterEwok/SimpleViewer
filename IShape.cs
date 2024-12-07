using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Viewer
{
    // Interface for shapes
    internal interface IShape
    {
        UIElement Render(double scale, double centerX, double centerY);

        Rect GetBounds();
    }
}

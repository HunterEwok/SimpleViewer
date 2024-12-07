using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    internal interface IDataLoader
    {
        List<IShape> LoadShapes(string filePath);
    }
}

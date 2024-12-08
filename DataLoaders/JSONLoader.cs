using System.IO;
using System.Text.Json;
using Viewer.Shapes;

namespace Viewer.DataLoaders
{
    // Loads shapes from a JSON file

    internal class JSONLoader : IDataLoader
    {
        public List<IShape> LoadShapes(string filePath) 
        {
            string jsonData = File.ReadAllText(filePath);

            var rawShapes = JsonSerializer.Deserialize<List<RawShape>>(jsonData);

            var shapes = new List<IShape>();

            if (rawShapes != null)
                shapes = rawShapes.Select(ParseShape).ToList();

            return shapes;
        }

        // Converts a raw shape from JSON into an IShape object
        private IShape ParseShape(RawShape rawShape)
        {
            return rawShape?.Type?.ToLower() switch
            {
                "line" => new LineShape(rawShape),
                "circle" => new CircleShape(rawShape),
                "triangle" => new TriangleShape(rawShape),
                _ => throw new NotSupportedException($"Unknown shape type: {rawShape?.Type}")
            };
        }
    }
}

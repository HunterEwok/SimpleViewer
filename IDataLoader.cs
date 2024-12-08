namespace Viewer
{
    internal interface IDataLoader
    {
        List<IShape> LoadShapes(string filePath);
    }
}

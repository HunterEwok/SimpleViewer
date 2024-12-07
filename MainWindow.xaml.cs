using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Viewer.DataLoaders;
using Viewer.Shapes;

namespace Viewer
{
    public partial class MainWindow : Window

    {
        private const string InputFilePath = "input.json"; // Path to the JSON input file

        private double _currentScale = 1.0; // Current zoom level

        private Point _lastMousePosition; // Last recorded mouse position for dragging

        private bool _isDragging; // Indicates if the canvas is being dragged

        private TranslateTransform _translateTransform = new(); // Transformation for panning

        private IDataLoader _dataLoader = new JSONLoader();

        public MainWindow()
        {
            InitializeComponent();

            // Subscribe to events for loading and resizing the window
            Loaded += MainWindow_Loaded;
            SizeChanged += MainWindow_SizeChanged;

            // Subscribe to mouse events for interaction
            DrawingCanvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            DrawingCanvas.MouseMove += Canvas_MouseMove;
            DrawingCanvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
            DrawingCanvas.MouseWheel += Canvas_MouseWheel;
        }

        // Draws shapes on the canvas
        private void DrawShapes(IEnumerable<IShape> shapes)
        {
            DrawingCanvas.Children.Clear();

            double canvasWidth = DrawingCanvas.ActualWidth;
            double canvasHeight = DrawingCanvas.ActualHeight;

            // Canvas size is not yet available
            if (canvasWidth == 0 || canvasHeight == 0)
                return;

            // Calculate initial scale to fit the drawing within the canvas
            double initialScale = Helper.CalculateScale(shapes, canvasWidth / 2, canvasHeight / 2);

            // Apply current zoom level to the scale
            double finalScale = initialScale * _currentScale;

            // Apply translation transformation for panning
            DrawingCanvas.RenderTransform = _translateTransform;

            // Draw each shape
            foreach (var shape in shapes)
            {
                DrawingCanvas.Children.Add(
                    shape.Render(finalScale, canvasWidth / 2, canvasHeight / 2));
            }
        }

        // Event triggered when the window is fully opened
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DrawShapes(_dataLoader.LoadShapes(InputFilePath));
        }

        // Event triggered when the window is resized
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawShapes(_dataLoader.LoadShapes(InputFilePath));
        }

        // Handles mouse wheel events for zooming in and out
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double zoomFactor = e.Delta > 0 ? 1.05 : 0.95;

            _currentScale *= zoomFactor;

            DrawShapes(_dataLoader.LoadShapes(InputFilePath));
        }

        // Handles mouse button press for starting a drag operation
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _lastMousePosition = e.GetPosition(DrawingCanvas);

            DrawingCanvas.CaptureMouse();
        }

        // Handles mouse movement for dragging
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var currentPosition = e.GetPosition(DrawingCanvas);
                var delta = currentPosition - _lastMousePosition;

                _translateTransform.X += delta.X;
                _translateTransform.Y += delta.Y;

                _lastMousePosition = currentPosition;
            }
        }

        // Handles mouse button release to end a drag operation
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;

            DrawingCanvas.ReleaseMouseCapture();
        }
    }
}
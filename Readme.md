# WSCAD Code Challenge: Vector Graphic Viewer

## Overview

This project implements a **Vector Graphic Viewer** that reads geometric primitives from a JSON file and displays them in a graphical user interface. The application is built to handle various shapes (lines, circles, triangles) and render them according to provided specifications.

The primary goal of this project is to demonstrate extensibility and maintainability while adhering to the provided requirements.

---

## Features

- **Rendering of Geometric Primitives**:  

  The application supports the following shapes:
  - Lines
  - Circles (filled or outlined)
  - Triangles (filled or outlined)

- **Input Format**:  

  The viewer reads data from a JSON file containing an array of objects with the following attributes:
  - **type**: Specifies the shape type (e.g., `line`, `circle`, `triangle`).
  - **coordinates**: Defines the location of the shape in Cartesian coordinates.
  - **color**: Defines the shape color in ARGB format.
  - **filled**: Specifies whether the shape is filled (if applicable).

- **Responsive Scaling**:  

  Shapes are proportionally scaled to fit the application window, regardless of the virtual size of the canvas.

- **Customizable Rendering**:  

  - Cartesian coordinate system with the Y-axis pointing upward.
  - Border width of 1 unit for all shapes.

- **Extensibility**:  

  The solution is designed with future scalability in mind:

  1. **New Shape Types**: Adding new primitives, such as rectangles, can be done by extending the shape hierarchy.
  2. **New Input Formats**: XML or other formats can be supported by implementing additional parsers.
  3. **Shape Inspection**: Additional functionality for selecting and inspecting primitives can be integrated with minimal effort.

---

## Installation

1. Clone this repository:

   ```bash 
   git clone https://github.com/HunterEwok/SimpleViewer.git

2. Open the solution in Visual Studio or your preferred IDE.

3. Build the project to restore dependencies.

Usage

1. Prepare a JSON file with shape definitions. Example:

[
  {
    "type": "line",
    "a": "-1,5; 3,4",
    "b": "2,2; 5,7",
    "color": "127; 255; 255; 255"
  },
  {
    "type": "circle",
    "center": "0; 0",
    "radius": 15.0,
    "filled": false,
    "color": "127; 255; 0; 0"
  },
  {
    "type": "triangle",
    "a": "-15; -20",
    "b": "15; -20",
    "c": "0; 21",
    "filled": true,
    "color": "127; 255; 0; 255"
  }
]

2. Run the application.
3. Load the JSON file into the viewer.
4. View the rendered primitives.

Example Output

The application will render:

� A line connecting specified points with the specified color.
� A circle at the defined center with the given radius, filled or outlined.
� A triangle connecting the specified vertices, filled or outlined.

Extensibility Plan

The solution is structured to accommodate future requirements:

1. New Shape Types:
� Introduce a new class implementing a common shape interface (e.g., IShape).
� Extend the rendering logic to recognize and process the new type.
2. New Input Formats:
� Implement additional file parsers (e.g., for XML).
� Add a format-specific reader class following a strategy pattern.

License

This project is distributed under the MIT License. See LICENSE for more details.
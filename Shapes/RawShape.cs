using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace Viewer.Shapes
{
    // Data structure for raw JSON shape data

    internal class RawShape
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("a")]
        public string? A { get; set; }

        [JsonPropertyName("b")]
        public string? B { get; set; }

        [JsonPropertyName("c")]
        public string? C { get; set; }

        [JsonPropertyName("center")]
        public string? Center { get; set; }

        [JsonPropertyName("radius")]
        public double? Radius { get; set; }

        [JsonPropertyName("filled")]
        public bool? Filled { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }
    }
}

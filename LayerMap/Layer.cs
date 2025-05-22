using System;
using System.Drawing;

namespace LayerMap {
    public class Layer {
        public Bitmap Image { get; set; }
        public byte Height { get; set; }

        public Layer(Bitmap image, byte height) {
            Image = image;
            Height = height;
        }
    }
}

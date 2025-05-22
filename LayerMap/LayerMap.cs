using System;
using System.Collections.Generic;
using WorldEditor;
using RegionMapping;
using System.Drawing;

namespace LayerMap
{
    public class LayerMap
    {
        public World World { get; set; }
        public RenderSettings RenderSettings { get; set; }
        public readonly byte Min;
        public readonly byte Max;

        private List<Layer> _layers { get; set; }
        public List<Layer> Layers { get { return _layers; } }

        public LayerMap(byte min, byte max) {
            World = new World();
            RenderSettings = new RenderSettings();
            Min = min;
            Max = max;
            _layers = new List<Layer>();
        }

        public void RenderLayers(LayerMapProgress progress) {
            _layers.Clear();

            Map map = new Map();
            map.RenderSettings = RenderSettings;

            for (byte i = Max; i >= Min; i--) {
                Scripts.MaxHeight = i;

                Bitmap image = map.GetRegionMap(World.Regions);
                _layers.Add(new Layer(image, i));

                progress.Current = i;
            }

            Scripts.MaxHeight = 255;
        }
        public LayerMapProgress GetNewProgress() {
            return new LayerMapProgress(Min, Max);
        }
        public void SaveAsVideo(int durationOfFramesInMS, string videoPath) {
            StitchVideo.CreateVideoFromLayers(_layers, durationOfFramesInMS, videoPath);
        }
    }
}

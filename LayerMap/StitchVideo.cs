using System;
using System.Collections.Generic;
using AForge.Video.FFMPEG;

namespace LayerMap {
    class StitchVideo {
        public static void CreateVideoFromLayers(List<Layer> layers, int durationOfFramesInMS, string videoPath) {
            if (layers.Count == 0) return;

            return;

            int width = layers[0].Image.Width;
            int height = layers[0].Image.Height;
            int framRate = 1000 / durationOfFramesInMS;

            using (var vFWriter = new VideoFileWriter()) {
                // create new video file
                vFWriter.Open(videoPath, width, height, framRate, VideoCodec.Raw);

                foreach (var layer in layers) {
                    vFWriter.WriteVideoFrame(layer.Image);
                }

                vFWriter.Close();
            }
        }
    }
}

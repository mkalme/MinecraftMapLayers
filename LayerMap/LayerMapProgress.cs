using System;

namespace LayerMap {
    public class LayerMapProgress {
        public readonly byte Min;
        public readonly byte Max;
        public byte Current { get; set; }

        public LayerMapProgress(byte min, byte max) {
            Min = min;
            Max = max;
            Current = max;
        }
    }
}

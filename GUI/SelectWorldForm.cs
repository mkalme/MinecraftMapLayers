using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldEditor;
using LayerMap;

namespace GUI {
    public partial class SelectWorldForm : Form {
        public SelectWorldForm()
        {
            InitializeComponent();
        }

        private void SelectWorldForm_Load(object sender, EventArgs e)
        {
            Test();
        }

        private void Test() {
            World world = new World(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\New World (4)");
            LayerMap.LayerMap layerMap = new LayerMap.LayerMap(50, 120);

            world.LoadRegion(0, 0);            
            layerMap.World = world;

            layerMap.RenderLayers(layerMap.GetNewProgress());

            System.Diagnostics.Debug.WriteLine("save video");
            layerMap.SaveAsVideo(100, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\videoLayertest.avi");
        }
    }
}

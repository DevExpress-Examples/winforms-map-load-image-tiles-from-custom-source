
using System;
using System.Windows.Forms;
using DevExpress.XtraMap;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace CustomProvider {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a map control, set its dock style and add it to the form.
            MapControl map = new MapControl();
            map.Dock = DockStyle.Fill;
            this.Controls.Add(map);

            // Create a layer to load image tiles from a local map data provider.
            ImageLayer imageTilesLayer = new ImageLayer();
            map.Layers.Add(imageTilesLayer);
            imageTilesLayer.DataProvider = new LocalProvider();

        }

        public class LocalProvider : MapDataProviderBase {

            readonly SphericalMercatorProjection projection = new SphericalMercatorProjection();

            public LocalProvider() {
                TileSource = new LocalTileSource(this);
            }

            public override ProjectionBase Projection {
                get {
                    return projection;
                }
            }

            protected override Size BaseSizeInPixels {
                get { return new Size(Convert.ToInt32(LocalTileSource.tileSize * 2), Convert.ToInt32(LocalTileSource.tileSize * 2)); }
            }
        }

        public class LocalTileSource : MapTileSourceBase {
            public const int tileSize = 256;
            public const int maxZoomLevel = 2;
            string directoryPath;

            internal static double CalculateTotalImageSize(double zoomLevel) {
                if (zoomLevel < 1.0)
                    return zoomLevel * tileSize * 2;
                return Math.Pow(2.0, zoomLevel) * tileSize;
            }

            public LocalTileSource(ICacheOptionsProvider cacheOptionsProvider) :
                base((int)CalculateTotalImageSize(maxZoomLevel), (int)CalculateTotalImageSize(maxZoomLevel), tileSize, tileSize, cacheOptionsProvider) {
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                directoryPath = dir.Parent.Parent.FullName;
            }

            public override Uri GetTileByZoomLevel(int zoomLevel, int tilePositionX, int tilePositionY) {
                if (zoomLevel <= maxZoomLevel) {
                    Uri u = new Uri(string.Format("file://" + directoryPath + "\\openstreetmap.org\\Hybrid_{0}_{1}_{2}.png", zoomLevel, tilePositionX, tilePositionY));
                    return u;
                }
                return null;
            }
        }
    }
}

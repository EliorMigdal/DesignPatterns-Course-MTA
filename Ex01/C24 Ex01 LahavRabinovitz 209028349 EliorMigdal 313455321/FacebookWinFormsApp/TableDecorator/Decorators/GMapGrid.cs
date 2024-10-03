using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Windows.Forms;

namespace BasicFacebookFeatures.TableDecorator.Decorators
{
    public class GMapGrid : GridDecorator
    {
        public GMapGrid(IGrid i_Decorator, (float i_X, float i_Y) i_Coordinates) : base(i_Decorator)
        {
            Grid.Controls.Add(initializeMap(i_Coordinates));
        }

        private GMapControl initializeMap((float i_X, float i_Y) i_Coordinates)
        {
            GMapControl map = new GMapControl
            {
                Dock = DockStyle.Fill,
                MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance,
                Position = new PointLatLng(i_Coordinates.i_X, i_Coordinates.i_Y),
                MinZoom = 0,
                MaxZoom = 18,
                Zoom = 12,
                AutoSize = true
            };

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(i_Coordinates.i_X, i_Coordinates.i_Y), GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            map.Overlays.Add(markersOverlay);

            return map;
        }
    }
}

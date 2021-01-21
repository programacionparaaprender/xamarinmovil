using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.ComponentModel;
using Xamarin.Forms.GoogleMaps;

namespace Contacts
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class frmGoogleMaps : ContentPage
    {
        public frmGoogleMaps()
        {
            InitializeComponent();
            //GeneratePins();
        }
        private void GeneratePins()
        {
            var pins = new List<Pin>
            {
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.87) },
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.77) },
                new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.97) },
            };

            foreach (var pin in pins)
            {
                // Podemos usar FromBundle, FromStream o FromView (custom view)
                //pin.Icon = BitmapDescriptorFactory.FromBundle("coffee_pin.png");
                map.Pins.Add(pin);
            }
        }

        private void map_MyLocationButtonClicked(object sender, MyLocationButtonClickedEventArgs e)
        {
            
        }

        private void map_PinClicked(object sender, PinClickedEventArgs e)
        {
            //string coordenadas = e.Pin.Position.ToString();
            
        }

        private void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            Pin pin = new Pin
            {
                Type = PinType.Place,
                Label = "This is my home",
                Address = "Here",
                Position = new Position(e.Point.Latitude, e.Point.Longitude)
            };
            map.Pins.Add(pin);

            var polygon1 = new Polygon();

            foreach (Pin pintemp in map.Pins)
            {
                polygon1.Positions.Add(new Position(pintemp.Position.Latitude, pintemp.Position.Longitude));
            }
            polygon1.StrokeWidth = 5f;
            polygon1.StrokeColor = Color.Red;
            polygon1.FillColor = Color.FromRgba(255, 0, 0, 160);
            if(map.Pins.Count > 2)
                map.Polygons.Add(polygon1);


        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            map.Pins.Clear();
            map.Polygons.Clear();
        }
    }
}
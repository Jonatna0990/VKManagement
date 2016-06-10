using System;
using System.Diagnostics;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
using VKCore.API.VKModels.Geo;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.Map
{
    public sealed partial class AddMapLocationControl : UserControl
    {

        private Action<GeoClass> geoActionCallback = null; 
        private Geolocator geolocator;
        private Geopoint position = null;
        UserControlFlyout flyout;

        public AddMapLocationControl(Action<GeoClass> geoActionCallback)
        {
            this.InitializeComponent();
            flyout = new UserControlFlyout();
            this.geoActionCallback = geoActionCallback;
            Loaded += AddMapLocationControl_Loaded;
        }

        private async void AddMapLocationControl_Loaded(object sender, RoutedEventArgs e)
        {
            MyMap.MapServiceToken = "UqkOBvNggQQQn5pWcqea~aY4anTwkAg6d1FKQEnz5bg~AgugbSfmMSz2Q8OVacMWhFT-xfpPUe4MebFzhCWJOo56sLHpxCYkMOvOCAJIira6";
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;
            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));

                MapIcon mapIcon = new MapIcon();
                mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Icons/Dark/Map/location.png"));
                mapIcon.Title = "Current Location";
                mapIcon.Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = geoposition.Coordinate.Point.Position.Latitude,
                    Longitude = geoposition.Coordinate.Point.Position.Longitude
                });
                position = mapIcon.Location;
                mapIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);
                MyMap.MapElements.Add(mapIcon);
                await MyMap.TrySetViewAsync(mapIcon.Location, 18D, 0, 0, MapAnimationKind.Bow);

               
             }
            catch (UnauthorizedAccessException)
            {
                Debug.WriteLine("Location service is turned off!");
                flyout.CloseFloyout();
                PopupEx popup = new PopupEx("Ошибка", "Определение местоположения невозможно. Включите геолокацию и повторите попытку.");
                popup.ShowAsync();
            }
        }

       

   
        private async void MyLocation_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));
                await MyMap.TrySetViewAsync(geoposition.Coordinate.Point, 18D);
           }
            catch (UnauthorizedAccessException)
            {
                Debug.WriteLine("Location service is turned off!");
                flyout.CloseFloyout();
                PopupEx popup = new PopupEx("Ошибка", "Определение местоположения невозможно. Включите геолокацию и повторите попытку.");
                popup.ShowAsync();
               
            }
        }

        private async void MyMap_OnMapTapped(MapControl sender, MapInputEventArgs args)
        {
            Geopoint pointToReverseGeocode = new Geopoint(args.Location.Position);

            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            var resultText = new StringBuilder();

            if (result.Status == MapLocationFinderStatus.Success)
            {
                resultText.AppendLine(result.Locations[0].Address.District + ", " + result.Locations[0].Address.Town + ", " + result.Locations[0].Address.Country);
            }

            Debug.WriteLine(resultText.ToString());
        }

        private void SaveLocation_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (position != null)
                geoActionCallback?.Invoke(new GeoClass() {@long = position.Position.Longitude, lat = position.Position.Latitude});
            flyout.CloseFloyout();
        }
    }
}

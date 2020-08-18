using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Android.OS;
using Xamarin.Essentials;

namespace Spidi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RetrieveLocation();
             
        }

        private async void RetrieveLocation()
        {
            map.IsShowingUser = true;

            try 
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest() 
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location == null)
                    Console.WriteLine("Error");
                else
                {
                    Position position = new Position(location.Latitude, location.Longitude);
                    map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
                }
                    
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine($"Handle not supported on device exception: {fnsEx.Message}");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Console.WriteLine($"Handle not enabled on device exception: {fneEx.Message}");
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine($"Handle permission exception: {pEx.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to get location: {ex.Message}");
            }
        }  

    }

}



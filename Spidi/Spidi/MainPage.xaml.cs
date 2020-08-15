using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Spidi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
        }

        private async void SetCurrentLocation() {
            //var position = await locator.GetPositionAsync(5000);
            //Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.0060899, 19.948572), Distance.FromMiles(1)));
        }
    }
}

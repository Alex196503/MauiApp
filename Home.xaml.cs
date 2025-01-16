using MauiAppBazaSportiva.Models;
using Microsoft.Maui.Devices.Sensors;

namespace MauiAppBazaSportiva;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var baza = (BazaSportiva)BindingContext;
        //  var address = baza.Address;
        // var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Baza Sportiva"
        };
        var bazalocation = new Location(46.77030905159401, 23.63664252114194);//pentru 
        await Map.OpenAsync(bazalocation, options);
    }
    // var bazalocation = locations?.FirstOrDefault();

}
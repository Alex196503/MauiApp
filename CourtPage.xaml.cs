using MauiAppBazaSportiva.Models;

namespace MauiAppBazaSportiva;


public partial class CourtPage : ContentPage
{
    Reservation reservation;
	public CourtPage(Reservation r1)
	{
		InitializeComponent();
        reservation = r1;
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var court = (Court)BindingContext;
        await App.Database.SaveCourtAsync(court);
        listViewCourts.ItemsSource = await App.Database.GetCourtsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var court = listViewCourts.SelectedItem as Court;
        await App.Database.DeleteCourtAsync(court);
        listViewCourts.ItemsSource = await App.Database.GetCourtsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listViewCourts.ItemsSource = await App.Database.GetCourtsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        if (listViewCourts.SelectedItem is Court selectedCourt)
        {
            var currentReservation = reservation;

            if (currentReservation != null)
            {
                currentReservation.CourtID = selectedCourt.ID;

                await App.Database.SaveReservationAsync(currentReservation);  

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Eroare", "Rezervarea curentã nu este validã", "OK");
            }
        }
        else
        {
            await DisplayAlert("Eroare", "Selecta?i un teren înainte de a continua.", "OK");
        }
    }


}
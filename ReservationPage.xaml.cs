using MauiAppBazaSportiva.Models;

namespace MauiAppBazaSportiva;

public partial class ReservationPage : ContentPage
{
    Member m1;
    public ReservationPage(Member member)
    {
        InitializeComponent();
        m1 = member;
        if(m1.Reservation == null)
    {
            m1.Reservation = new Reservation(); 
        }

        BindingContext = m1;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var member = (Member)BindingContext;

        if (member == null)
        {
            await DisplayAlert("Eroare", "Membrul curent este null.", "OK");
            return;
        }

        if (member.Reservation == null)
        {
            member.Reservation = new Reservation
            {
                MemberID = member.ID,
            };
        }

        member.Reservation.ReservationDate = DateTime.Now;
        member.Reservation.Duration = int.Parse(((Entry)FindByName("DurationEntry")).Text);

        await App.Database.SaveReservationAsync(member.Reservation);

        listViewReservation.ItemsSource = await App.Database.GetReservationsAsync();
    }



    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var reservation = listViewReservation.SelectedItem as Reservation;
        await App.Database.DeleteReservationAsync(reservation);
        listViewReservation.ItemsSource = await App.Database.GetReservationsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var member = (Member)BindingContext;

        if (member?.Reservation != null)
        {
            var reservation = member.Reservation;

            var courts = await App.Database.GetCourtsForReservation(reservation.ID);

            listViewCourts.ItemsSource = courts;
        }
        else
        {
            await DisplayAlert("Eroare", "Nu existã o rezervare asociatã membrului.", "OK");
        }
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        if (listViewReservation.SelectedItem is Reservation selectedReservation)
        {
            var currentMember = m1; 

            if (currentMember != null)
            {
                currentMember.ReservationID = selectedReservation.ID;

                await App.Database.SaveMemberAsync(currentMember);

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Eroare", "Membrul curent nu este valid.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Eroare", "Selecta?i o rezervare înainte de a continua.", "OK");
        }
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        var reservation = listViewReservation.SelectedItem as Reservation;

        if (reservation == null)
        {
            await DisplayAlert("Eroare", "Selecta?i o rezervare înainte de a continua.", "OK");
            return;
        }

        var courtPage = new CourtPage(reservation)
        {
            BindingContext = reservation.Court ?? new Court() 
        };

        await Navigation.PushAsync(courtPage);
    }


}
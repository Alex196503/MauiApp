using MauiAppBazaSportiva.Models;

namespace MauiAppBazaSportiva;

public partial class MembershipPage : ContentPage
{
    Member m1;
    public MembershipPage(Member member)
    {
        InitializeComponent();
        m1 = member;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var membership = (Membership)BindingContext;
        await App.Database.SaveMembershipAsync(membership);
        listView.ItemsSource = await App.Database.GetMembershipsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var membership = listView.SelectedItem as Membership;
        await App.Database.DeleteMembershipAsync(membership);
        listView.ItemsSource = await App.Database.GetMembershipsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Membership selectedMembership;

        if (listView.SelectedItem != null)
        {
            selectedMembership = listView.SelectedItem as Membership;

            var currentMember = m1;

            if (currentMember != null)
            {
                currentMember.MembershipID = selectedMembership.ID;

                await App.Database.SaveMemberAsync(currentMember);
            }

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Eroare", "Selecta?i un abonament înainte de a continua.", "OK");
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMembershipsAsync();
    }
}
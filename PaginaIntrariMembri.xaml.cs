using MauiAppBazaSportiva.Models;

namespace MauiAppBazaSportiva;

public partial class PaginaIntrariMembri : ContentPage
{
	public PaginaIntrariMembri()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMembersAsync();
    }
    async void OnMemberAddedClicked(object sender, EventArgs e)
    {
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new Member()
            });
        }
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as Member
            });
        }
    }

}
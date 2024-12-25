namespace MauiAppBazaSportiva;
using MauiAppBazaSportiva.Models;
public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var member = (Member)BindingContext;
        await App.Database.SaveMemberAsync(member);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var member = (Member)BindingContext;
        await App.Database.DeleteMemberAsync(member);
        await Navigation.PopAsync();
    }

}
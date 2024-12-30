using MauiAppBazaSportiva.Models;

namespace MauiAppBazaSportiva;

public partial class MembershipPage : ContentPage
{

	public Membership SelectedMembership { get; set; }
  public MembershipPage(Membership membership=null)
	{

		InitializeComponent();
		BindingContext = membership ?? new Membership();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {

        if (BindingContext is Membership membership)
        {
            await App.Database.SaveMembershipAsync(membership);

            listView.ItemsSource = await App.Database.GetMembershipsAsync();
        }
        else
        {
         
            await DisplayAlert("Error", "BindingContext is not set to a Membership.", "OK");
        }
    }

    async void OnDeleteButtonClicked(object sender,EventArgs e)
	{
		var membership = listView.SelectedItem as Membership;
		await App.Database.DeleteMembershipAsync(membership);
		listView.ItemsSource = await App.Database.GetMembershipsAsync();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetMembershipsAsync();
	}
	async void OnAddButtonClicked(object sender,EventArgs e)
	{
		Membership m1;
		if(listView.SelectedItem is Membership selectedMembership)
		{
			var member = new Member()
			{
			};
			if(selectedMembership.Members==null)
			{
				selectedMembership.Members = new List<Member>();
			}
			await App.Database.SaveMemberAsync(member);
			selectedMembership.Members ??= new List<Member>();
			selectedMembership.Members.Add(member);
			await DisplayAlert("Succes", "Membru adaugat cu succes","OK");
			await Navigation.PopAsync();

		}
		else
		{
			await DisplayAlert("Eroare", "Te rog selecteaza un abonament inainte de adaugarea membrului.", "OK");
		}
	}

}
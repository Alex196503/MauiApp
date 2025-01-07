namespace MauiAppBazaSportiva;
using MauiAppBazaSportiva.Models;
public partial class ListPage : ContentPage
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public Membership Membership { get; set; } 
    public Trainer Trainer { get; set; }
    public string Specialization { get; set; }
    public ListPage()
	{
		InitializeComponent();
        BindingContext = this;
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
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MembershipPage((Member)
       this.BindingContext)
        {
            BindingContext = new Membership()
        });


    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var member = (Member)BindingContext;

        var membershipsTask = App.Database.GetMemberMembershipsAsync(member.ID);
        var trainersTask = App.Database.GetMemberTrainersAsync(member.ID);
        await Task.WhenAll(membershipsTask, trainersTask);
        listView.ItemsSource = await membershipsTask;
        listViewTrainer.ItemsSource = await trainersTask;
    }

    async void OnChooseButtonClickedTrainer(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TrainerPage((Member)
       this.BindingContext)
        {
            BindingContext = new Trainer()
        });

    }
    
}
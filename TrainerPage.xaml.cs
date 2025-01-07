using MauiAppBazaSportiva.Models;

namespace MauiAppBazaSportiva;

public partial class TrainerPage : ContentPage
{
    Member m1;
	public TrainerPage(Member member)
	{
		InitializeComponent();
        m1 = member;
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var trainer = (Trainer)BindingContext;
        await App.Database.SaveTrainerAsync(trainer);
        listViewTrainer.ItemsSource = await App.Database.GetTrainersAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var trainer = listViewTrainer.SelectedItem as Trainer;
        await App.Database.DeleteTrainerAsync(trainer);
        listViewTrainer.ItemsSource = await App.Database.GetTrainersAsync();
    }
    
    async void OnAddButtonClicked(object sender,EventArgs e)
    {
        Trainer selectedTrainer;
        if(listViewTrainer.SelectedItem!=null)
        {
            selectedTrainer= listViewTrainer.SelectedItem as Trainer;
            var currentMember = m1;
            if(currentMember!=null)
            {
                currentMember.TrainerID = selectedTrainer.ID;
                await App.Database.SaveMemberAsync(currentMember);
            }
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Eroare", "Selectati un trainer inainte de a continua!", "OK");
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listViewTrainer.ItemsSource = await App.Database.GetTrainersAsync();
    }
}
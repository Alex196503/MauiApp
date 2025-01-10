namespace MauiAppBazaSportiva;
using MauiAppBazaSportiva.Models;
public partial class ReviewPage : ContentPage
{
    Trainer trainer;
    public ReviewPage(Trainer trainer1)
    {
        InitializeComponent();
        trainer = trainer1;

    }
   
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var review = (Review)BindingContext;
            await App.Database.SaveReviewAsync(review);
            listViewReviews.ItemsSource = await App.Database.GetReviewsAsync();
        }

    
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var review = listViewReviews.SelectedItem as Review;
        await App.Database.DeleteReviewAsync(review);
        listViewReviews.ItemsSource = await App.Database.GetReviewsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listViewReviews.ItemsSource = await App.Database.GetReviewsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Review selectedReview;

        if (listViewReviews.SelectedItem != null)
        {
            selectedReview = listViewReviews.SelectedItem as Review;

            var currentTrainer = trainer;

            if (currentTrainer != null)
            {
                currentTrainer.ReviewID = selectedReview.ID;

                await App.Database.SaveTrainerAsync(currentTrainer);
            }

            await Navigation.PopAsync();
            var reviews = await App.Database.GetReviewForTrainersAsync(currentTrainer.ID);
            listViewReviews.ItemsSource = reviews;
        }
        else
        {
            await DisplayAlert("Eroare", "Selectati un review înainte de a continua.", "OK");
        }
    }

}
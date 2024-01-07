namespace PizzaApp.Pages;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    
    async void TapgestureRecognizer_Tapped(System.Object sender,
        Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
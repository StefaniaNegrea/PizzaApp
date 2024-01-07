namespace PizzaApp.Pages;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ExecuteAnimationsAsync();
    }

    private async Task ExecuteAnimationsAsync()
    {
        await img.ScaleTo(1.5);
        await msg.ScaleTo(1);

        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(1);

        await homeBtn.FadeTo(1, length: 500);
        await homeBtn.ScaleTo(1);
    }


    async void HomeBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}", animate: true);
    }
}
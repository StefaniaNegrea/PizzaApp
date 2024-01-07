namespace PizzaApp.Pages;

public partial class CartPage : ContentPage
{
	private readonly CartViewModel cartViewModel;
	public CartPage(CartViewModel _cartViewModel)
	{
		_cartViewModel = cartViewModel;
		InitializeComponent();
		BindingContext = _cartViewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(AllPizzasPage));
    }
}
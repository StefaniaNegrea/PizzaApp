#if IOS
using UIKit;
#endif


namespace PizzaApp.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;

    public Color StatusBarColor { get; private set; }

    public DetailPage(DetailsViewModel detailsViewModel)
	{
        _detailsViewModel = detailsViewModel;
        InitializeComponent();
		BindingContext = _detailsViewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if IOS
        var bottom = UIKit.UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;

        bottomBox.Margin = new Thickness(-1, 0, -1, (bottom + 1) * -1);
#endif
    }

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("..", animate: true);
    }

   


}
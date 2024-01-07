

namespace PizzaApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Pizza> CartItemRemoved;
        public event EventHandler<Pizza> CartItemUpdated;
        public event EventHandler CartCleared;

        public ObservableCollection<Pizza> Items { get; set; }

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(i=> i.Name == pizza.Name);
            if(item is not null)
            {
                item.CartQuantity = pizza.CartQuantity;
            }
            else
            {
                Items.Add(pizza.Clone());
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.Green
                };
                var snackbar = Snackbar.Make($"'{item.Name}' sters din cos!",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                        CartItemUpdated?.Invoke(this, item);
                    }, "Inapoi", TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }

        }

        [RelayCommand]
        private async void ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Doresti sa stergi?", "Esti sigur ca doresti sa stergi?", "Da", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();

                CartCleared?.Invoke(this, EventArgs.Empty);

                await Toast.Make("Cos sters!", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }
    }
}

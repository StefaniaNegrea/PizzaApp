using System;


namespace PizzaApp.ViewModels
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel) 
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;

            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;

        }

        private void OnCartCleared(object _, EventArgs e) => Pizza.CartQuantity = 0;

        private void OnCartItemRemoved(object _, Pizza p) =>
            OnCartItemChanged(p, 0);
        private void OnCartItemUpdated(object _, Pizza p) =>
            OnCartItemChanged(p, p.CartQuantity);

        private void OnCartItemChanged( Pizza p, int quantity)
        {
            if(p.Name == Pizza.Name)
            {
                Pizza.CartQuantity = quantity;
            }
        }


        [ObservableProperty]
        private Pizza _pizza;

        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
        }

        [RelayCommand]
        public void RemoveToCart()
        {
            if (Pizza.CartQuantity > 0)
            {
                Pizza.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Pizza);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if(Pizza.CartQuantity>0) 
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Selecteaza cantitatea folosind butonul plus (+)", ToastDuration.Short)
                    .Show();
            }
        }

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;

            GC.SuppressFinalize(this);
        }
    }
}

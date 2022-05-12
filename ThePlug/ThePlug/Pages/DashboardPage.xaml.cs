using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePlug.Models;
using ThePlug.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThePlug.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public ObservableCollection<Order> OrdersPendingCollection;


        public DashboardPage()
        {
            InitializeComponent();
            OrdersPendingCollection = new ObservableCollection<Order>();
            LblUserName.Text = Preferences.Get("userName", string.Empty);
            GetPendingOrders();
        }

        
        private async void GetPendingOrders()
        {
            var orders = await ApiAdminService.GetPendingOrders();
            foreach (var order in orders)
            {
                OrdersPendingCollection.Add(order);
            }
            LvOrders.ItemsSource = OrdersPendingCollection;
        }
        private void LvOrders_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var currentSelection = e.SelectedItem as Order;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new OrderDetailPage(currentSelection.Id, currentSelection.OrderTotal));
            ((ListView)sender).SelectedItem = null;
        }

        private async void TapMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        private async void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
            //CloseHamburgerMenu();
        }
        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }

        private void TapOrders_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CompletedOrdersPage());
        }

        private void TapContact_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new FeedbackPage());
        }

        
    }
}
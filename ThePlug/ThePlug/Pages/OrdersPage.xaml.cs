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
    public partial class OrdersPage : ContentPage
    {
        public ObservableCollection<OrderByUser> OrdersCollection;
        public OrdersPage()
        {
            InitializeComponent();
            OrdersCollection = new ObservableCollection<OrderByUser>();
            GetOrderItems();
        }

        private async void GetOrderItems()
        {
            var orders = await ApiService.GetOrdersByUser(Preferences.Get("userId", 0));
            foreach(var order in orders)
            {
                OrdersCollection.Add(order);
            }
            LvOrders.ItemsSource = OrdersCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void LvOrders_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var currentSelection = e.SelectedItem as OrderByUser;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new OrderDetailPage(currentSelection.Id, currentSelection.OrderTotal));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
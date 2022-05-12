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
    public partial class OrderDetailPage : ContentPage
    {
        public ObservableCollection<OrderDetail> OrderDetailCollection;
        public OrderDetailPage(int orderId, double orderTotal)
        {
            InitializeComponent();
            LblTotalPrice.Text = "R" + orderTotal;
            OrderDetailCollection = new ObservableCollection<OrderDetail>();
            GetOrdersDetail(orderId);
        }

        private async void GetOrdersDetail(int orderId)
        {
            Preferences.Set("orderId", orderId);
          var orderDetails = await ApiService.GetOrderDetails(orderId);
            foreach(var orderDetail in orderDetails)
            {
                OrderDetailCollection.Add(orderDetail);
            }
            LvOrderDetail.ItemsSource = OrderDetailCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnCompleted_Clicked(object sender, EventArgs e)
        {
            Order order = new Order();
            var orderId = order.Id = Preferences.Get("orderId", 0);
            var response = await ApiAdminService.MarkOrderComplete(orderId, order);
            if (response)
            {
                await DisplayAlert("", "The order is successfully completed.", "Alright");
                Application.Current.MainPage = new NavigationPage(new DashboardPage());
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }
    }
}
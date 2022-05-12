using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePlug.Models;
using ThePlug.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThePlug.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        public ObservableCollection<Complaint> ComplaintCollection;

        public FeedbackPage()
        {
            InitializeComponent();
            ComplaintCollection = new ObservableCollection<Complaint>();
            GetComplaints();

        }
        private async void GetComplaints()
        {
            var orders = await ApiAdminService.GetComplaints();
            foreach (var order in orders)
            {
                ComplaintCollection.Add(order);
            }
            LvOrders.ItemsSource = ComplaintCollection;
        }
        /*private void LvOrders_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var currentSelection = e.SelectedItem as OrderByUser;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new OrderDetailPage(currentSelection.Id, currentSelection.OrderTotal));
            ((ListView)sender).SelectedItem = null;
        }*/
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
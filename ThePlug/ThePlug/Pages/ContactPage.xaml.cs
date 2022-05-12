using System;
using System.Collections.Generic;
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
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnSendMessage_Clicked(object sender, EventArgs e)
        {
           var complaint = new Complaint();
            complaint.FullName = EntFullName.Text;
            complaint.Email = EntEmail.Text;
            complaint.PhoneNumber = EntPhoneNumber.Text;
            complaint.Title = EntTitle.Text;
            complaint.Description = EntDescription.Text;

           var response = await ApiService.RegisterComplaint(complaint);
            if (response)
            {
                await DisplayAlert("", "Your complaint has been registered", "Alright");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }
    }
}
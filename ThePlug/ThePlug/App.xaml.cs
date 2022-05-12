using System;
using ThePlug.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThePlug
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           var accessToken = Preferences.Get("accessToken", string.Empty);
           var userName = Preferences.Get("userName", string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                MainPage = new NavigationPage(new SignupPage());
                
            }
            else
            {
                if (userName == "Zamani")
                {
                    MainPage = new NavigationPage(new DashboardPage());
                }
                else
                {
                    MainPage = new NavigationPage(new HomePage());
                }
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

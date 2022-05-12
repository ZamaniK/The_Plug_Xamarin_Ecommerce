using Plugin.FilePicker;
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
    public partial class AddProductPage : ContentPage
    {
        public ObservableCollection<Category> CategoriesCollection;
        //ObservableCollection<Category> Items1 = new ObservableCollection<Category>();
        List<string> Items1 = new List<string>();
        List<string> Items2 = new List<string>();
        bool IsItem1 = true;
        public AddProductPage()
        {
            InitializeComponent();
            CategoriesCollection = new ObservableCollection<Category>();


            for (int i = 0; i < 4; i++)
            {
                Items1.Add(i.ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                Items2.Add(i.ToString());
            }

            dropdown.ItemsSource = Items1;
            dropdown.SelectedIndex = 1;
            dropdown.ItemSelected += OnDropdownSelected;
        }
        private void OnDropdownSelected(object sender, ItemSelectedEventArgs e)
        {
            label.Text = IsItem1 ? Items1[e.SelectedIndex] : Items2[e.SelectedIndex];
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            
        }
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnAddProduct_Clicked(object sender, EventArgs e)
        {
            var product = new Product();
            product.Name = EntName.Text;
            product.Price = Convert.ToDouble(EntPrice.Text);
            product.Detail = EntDetail.Text;
            product.ImageUrl = lblImageUrl.Text;
            //dropdown.ItemsSource = IsItem1 ? Items2 : Items1;
            //dropdown.SelectedIndex = IsItem1 ? Convert.ToInt32(Items2) : Convert.ToInt32(Items1);
            product.CategoryId = 1;
            
            var response = await ApiAdminService.AddProduct(product);
            if (response)
            {
                await DisplayAlert("", "The product has been added", "Alright");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();
            if (file != null)
            {
                lblImageUrl.Text = file.FileName;
            }
        }
        /*
                private async void EntCategory_SelectedIndexChanged(object sender, EventArgs e)
                {
                    var categories = await ApiService.GetCategories();
                    foreach (var category in categories)
                    {
                        CategoriesCollection.Add(category);
                    }
                    var _picker = sender as Picker;
                   // EntCategory.ItemsSource = CategoriesCollection;
                    var collection = CategoriesCollection;
                    var index = _picker.SelectedIndex;
                     EntCategory.ItemsSource = new ObservableCollection<Category>(collection[index].Categories);

                }
            }
        */
    } 
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("ThePlug.Pages.PlaceOrderPage.xaml", "Pages/PlaceOrderPage.xaml", typeof(global::ThePlug.Pages.PlaceOrderPage))]

namespace ThePlug.Pages {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Pages\\PlaceOrderPage.xaml")]
    public partial class PlaceOrderPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TapGestureRecognizer TapBack;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Entry EntName;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Entry EntPhone;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Editor EntAddress;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Button BtnPlaceOrder;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(PlaceOrderPage));
            TapBack = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TapGestureRecognizer>(this, "TapBack");
            EntName = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "EntName");
            EntPhone = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "EntPhone");
            EntAddress = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Editor>(this, "EntAddress");
            BtnPlaceOrder = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "BtnPlaceOrder");
        }
    }
}

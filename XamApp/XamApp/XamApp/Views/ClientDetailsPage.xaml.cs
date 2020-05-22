using System;
using XamApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetailsPage : BaseContentPage<ClientDetailsPageViewModel>
    {
        public ClientDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private void EditTapped(object sender, EventArgs e)
        {
            ViewModel.EditTappedEventHandler?.Invoke(sender, e);
        }
    }
}

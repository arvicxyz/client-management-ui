using System;
using XamApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientListPage : BaseContentPage<ClientListPageViewModel>
    {
        public ClientListPage()
        {
            InitializeComponent();
            this.Padding = new Thickness(0, App.StatusBarHeight, 0, 0);
        }

        private void ClientListItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ClientListItemTappedEventHandler?.Invoke(sender, e);
        }

        private void FilterTapped(object sender, EventArgs e)
        {
            ViewModel.FilterTappedEventHandler?.Invoke(sender, e);
        }

        private void SortTapped(object sender, EventArgs e)
        {
            ViewModel.SortTappedEventHandler?.Invoke(sender, e);
        }

        private void FilterTypeChanged(object sender, Syncfusion.XForms.Buttons.StateChangedEventArgs e)
        {
            ViewModel.FilterTypeChangedEventHandler?.Invoke(sender, e);
        }

        private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchCommand?.Execute(e);
        }
    }
}

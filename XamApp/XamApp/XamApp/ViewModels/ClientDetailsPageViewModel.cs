using System;
using XamApp.Models.Local;
using XamApp.Services;
using XamApp.Views;

namespace XamApp.ViewModels
{
    public class ClientDetailsPageViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Constructors

        public ClientDetailsPageViewModel()
        {
            PageTitle = "Details";

            _selectedClient = new ClientModel();
        }

        #endregion

        #region Private Methods

        private async void EditTappedEvent(object sender, EventArgs e)
        {
            var page = new ClientAddEditPage();
            page.ViewModel.IsEditMode = true;
            page.ViewModel.SetPageTitle();
            page.ViewModel.SetSelectedClient(SelectedClient.Id);
            await Navigation.PushAsync(page);
        }

        #endregion

        #region Public Methods

        public void SetSelectedClient(int id)
        {
            ClientService service = new ClientService();
            SelectedClient = service.GetClientById(id);
        }

        #endregion

        #region Commands

        private event EventHandler<EventArgs> _editTappedEventHandler;
        public EventHandler<EventArgs> EditTappedEventHandler
        {
            get { return _editTappedEventHandler = _editTappedEventHandler ?? new EventHandler<EventArgs>(EditTappedEvent); }
        }

        #endregion

        #region Properties

        private ClientModel _selectedClient;
        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set { SetProperty(ref _selectedClient, value, "SelectedClient"); }
        }

        #endregion
    }
}

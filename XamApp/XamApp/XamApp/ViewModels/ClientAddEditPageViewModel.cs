using System;
using System.Threading.Tasks;
using System.Windows.Input;
using XamApp.Models.Local;
using XamApp.Services;
using XamApp.ViewModels.Commands;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class ClientAddEditPageViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        #region Constructors

        public ClientAddEditPageViewModel()
        {
            _isEditMode = false;
            _selectedClient = new ClientModel();
            _selectedClient.ProfileImage = "img_profile";
        }

        #endregion

        #region Private Methods

        private async Task TapStateEvent(object obj)
        {
            // Show dropdown popup here with search function
        }

        #endregion

        #region Public Methods

        public void SetPageTitle()
        {
            if (IsEditMode)
                PageTitle = "Edit Client";
            else
                PageTitle = "Add Client";
        }

        public void SetSelectedClient(int id)
        {
            ClientService service = new ClientService();
            SelectedClient = service.GetClientById(id);
        }

        #endregion

        #region Commands

        private ICommand _tapStateCommand;
        public ICommand TapStateCommand
        {
            get { return _tapStateCommand = _tapStateCommand ?? new DelegateCommand(async (obj) => await TapStateEvent(obj)); }
        }

        #endregion

        #region Properties

        private ClientModel _selectedClient;
        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set { SetProperty(ref _selectedClient, value, "SelectedClient"); }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set { SetProperty(ref _isEditMode, value, "IsEditMode"); }
        }

        #endregion
    }
}

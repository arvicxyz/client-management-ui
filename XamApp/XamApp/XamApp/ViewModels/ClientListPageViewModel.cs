using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Syncfusion.XForms.Buttons;
using XamApp.Models.Enums;
using XamApp.Models.Local;
using XamApp.Services;
using XamApp.Utilities;
using XamApp.ViewModels.Commands;
using XamApp.Views;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class ClientListPageViewModel : BaseViewModel
    {
        #region Fields

        private readonly string[] _filters = { "Date", "Sales Reps", "Customer Status", "Source", "Vehicle" };

        private List<ClientModel> _originalList;

        #endregion

        #region Constructors

        public ClientListPageViewModel()
        {
            PageTitle = (string)App.Current.Resources["AppNameString"];

            _originalList = new List<ClientModel>();

            _isSearchBarVisible = false;
            _isClientListVisible = false;
            _isListEmpty = false;
            _isSearchEmpty = false;
            _willFilter = false;
            _sortOpacity = 1;
            _filterType = _filters[0];
            _searchText = string.Empty;
            _sortIconImage = "ic_sort_asc.png";
            _clientList = new ObservableCollection<ClientModel>();

            SortIconImage = AppSettings.SortSettings == (int)SortValue.ASCENDING ? "ic_sort_asc.png" : "ic_sort_des.png";

            SetupClientList();
        }

        #endregion

        #region Private Methods

        private async void SetupClientList()
        {
            IsBusy = true;
            //await Task.Delay(5000);

            var service = new ClientService();
            var clientList = service.GetClients();

            SortItems(clientList);

            IsBusy = false;

            if (clientList.Count > 0)
            {
                IsSearchBarVisible = true;
                IsClientListVisible = true;
                IsListEmpty = false;
            }
            else
            {
                IsSearchBarVisible = false;
                IsClientListVisible = false;
                IsListEmpty = true;
            }
        }

        private async void ClientListItemTappedEvent(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is ClientModel item))
                return;

            await Task.Run(() =>
            {
                var page = new ClientDetailsPage();
                page.ViewModel.SetSelectedClient(item.Id);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(page);
                    await Task.Delay(500);
                    (sender as ListView).SelectedItem = null;
                });
            });
        }

        private void FilterTappedEvent(object sender, EventArgs e)
        {
            WillFilter = !WillFilter;
        }

        private void SortTappedEvent(object sender, EventArgs e)
        {
            if (ClientList.Count <= 1)
                return;
            var sortIcon = (Image)sender;
            AppSettings.SortSettings = AppSettings.SortSettings == (int)SortValue.ASCENDING ? (int)SortValue.DESCENDING : (int)SortValue.ASCENDING;
            sortIcon.Source = AppSettings.SortSettings == (int)SortValue.ASCENDING ? "ic_sort_asc.png" : "ic_sort_des.png";
            SortItems(ClientList.ToList());
        }

        private void FilterTypeChangedEvent(object sender, StateChangedEventArgs e)
        {
            if (e.IsChecked.HasValue && e.IsChecked.Value)
            {
                var filterText = (sender as SfRadioButton).Text;
                FilterType = filterText;
            }
        }

        private void FilterEvent()
        {
            WillFilter = !WillFilter;
            if (FilterType.Equals(_filters[0])) // Date
            {
                // TODO: Filter here...
            }
            else if (FilterType.Equals(_filters[1])) // Sales Reps
            {
                // TODO: Filter here...
            }
            else if (FilterType.Equals(_filters[2])) // Customer Status
            {
                // TODO: Filter here...
            }
            else if (FilterType.Equals(_filters[3])) // Source
            {
                // TODO: Filter here...
            }
            else if (FilterType.Equals(_filters[4])) // Vehicle
            {
                // TODO: Filter here...
            }
        }

        private void SearchEvent(object sender)
        {
            if (_originalList.Count <= 0)
                _originalList = ClientList.ToList();

            if (sender == null)
            {
                // Search Command

                if (!string.IsNullOrEmpty(SearchText))
                {
                    SearchItems(SearchText);
                }
                else
                {
                    ClientList = new ObservableCollection<ClientModel>(_originalList);
                    _originalList.Clear();
                }
            }
            else
            {
                // Text Changed Event

                var searchText = ((TextChangedEventArgs)sender).NewTextValue;
                if (!string.IsNullOrEmpty(searchText))
                {
                    SearchItems(searchText);
                }
                else
                {
                    ClientList = new ObservableCollection<ClientModel>(_originalList);
                    _originalList.Clear();
                }
            }

            // Do not update views when app first opens
            if (ClientList.Count <= 0 && string.IsNullOrEmpty(SearchText))
                return;

            UpdateViews();
        }

        private void SortItems(List<ClientModel> clientList)
        {
            var sortedList = AppSettings.SortSettings == (int)SortValue.ASCENDING ?
                clientList.OrderBy(x => x.DateCreated).ToList() :
                clientList.OrderByDescending(x => x.DateCreated).ToList();
            ClientList = new ObservableCollection<ClientModel>(sortedList);

            if (_originalList.Count <= 0)
                return;
            _originalList = AppSettings.SortSettings == (int)SortValue.ASCENDING ?
                _originalList.OrderBy(x => x.DateCreated).ToList() :
                _originalList.OrderByDescending(x => x.DateCreated).ToList();
        }

        private void SearchItems(string keyword)
        {
            var searchList = _originalList.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).ToList();
            ClientList = new ObservableCollection<ClientModel>(searchList);
        }

        private void UpdateViews()
        {
            if (ClientList.Count <= 1)
            {
                SortOpacity = 0.3;
            }
            else
            {
                SortOpacity = 1;
            }

            if (ClientList.Count > 0)
            {
                IsClientListVisible = true;
                IsSearchEmpty = false;
            }
            else
            {
                IsClientListVisible = false;
                IsSearchEmpty = true;
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Commands

        private event EventHandler<ItemTappedEventArgs> _clientListItemTappedEventHandler;
        public EventHandler<ItemTappedEventArgs> ClientListItemTappedEventHandler
        {
            get { return _clientListItemTappedEventHandler = _clientListItemTappedEventHandler ?? new EventHandler<ItemTappedEventArgs>(ClientListItemTappedEvent); }
        }

        private event EventHandler<EventArgs> _filterTappedEventHandler;
        public EventHandler<EventArgs> FilterTappedEventHandler
        {
            get { return _filterTappedEventHandler = _filterTappedEventHandler ?? new EventHandler<EventArgs>(FilterTappedEvent); }
        }

        private event EventHandler<EventArgs> _sortTappedEventHandler;
        public EventHandler<EventArgs> SortTappedEventHandler
        {
            get { return _sortTappedEventHandler = _sortTappedEventHandler ?? new EventHandler<EventArgs>(SortTappedEvent); }
        }

        private event EventHandler<StateChangedEventArgs> _filterTypeChangedEventHandler;
        public EventHandler<StateChangedEventArgs> FilterTypeChangedEventHandler
        {
            get { return _filterTypeChangedEventHandler = _filterTypeChangedEventHandler ?? new EventHandler<StateChangedEventArgs>(FilterTypeChangedEvent); }
        }

        private ICommand _filterCommand;
        public ICommand FilterCommand
        {
            get { return _filterCommand = _filterCommand ?? new DelegateCommand((obj) => FilterEvent()); }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand = _searchCommand ?? new DelegateCommand((obj) => SearchEvent(obj)); }
        }

        #endregion

        #region Properties

        private ObservableCollection<ClientModel> _clientList;
        public ObservableCollection<ClientModel> ClientList
        {
            get { return _clientList; }
            set { SetProperty(ref _clientList, value, "ClientList"); }
        }

        private string _sortIconImage;
        public string SortIconImage
        {
            get { return _sortIconImage; }
            set { SetProperty(ref _sortIconImage, value, "SortIconImage"); }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value, "SearchText"); }
        }

        private string _filterType;
        public string FilterType
        {
            get { return _filterType; }
            set { SetProperty(ref _filterType, value, "FilterType"); }
        }

        private double _sortOpacity;
        public double SortOpacity
        {
            get { return _sortOpacity; }
            set { SetProperty(ref _sortOpacity, value, "SortOpacity"); }
        }

        private bool _willFilter;
        public bool WillFilter
        {
            get { return _willFilter; }
            set { SetProperty(ref _willFilter, value, "WillFilter"); }
        }

        private bool _isSearchEmpty;
        public bool IsSearchEmpty
        {
            get { return _isSearchEmpty; }
            set { SetProperty(ref _isSearchEmpty, value, "IsSearchEmpty"); }
        }

        private bool _isListEmpty;
        public bool IsListEmpty
        {
            get { return _isListEmpty; }
            set { SetProperty(ref _isListEmpty, value, "IsListEmpty"); }
        }

        private bool _isClientListVisible;
        public bool IsClientListVisible
        {
            get { return _isClientListVisible; }
            set { SetProperty(ref _isClientListVisible, value, "IsClientListVisible"); }
        }

        private bool _isSearchBarVisible;
        public bool IsSearchBarVisible
        {
            get { return _isSearchBarVisible; }
            set { SetProperty(ref _isSearchBarVisible, value, "IsSearchBarVisible"); }
        }

        #endregion
    }
}

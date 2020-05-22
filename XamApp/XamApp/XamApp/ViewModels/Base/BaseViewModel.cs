using System.ComponentModel;
using XamApp.Models.Interfaces;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class BaseViewModel : IBaseViewModel, INotifyPropertyChanged
    {
        public Page Page { get; set; }

        public INavigation Navigation { get; set; }

        public BaseViewModel()
        {
            _isBusy = false;
            _pageTitle = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T item, T value, string property)
        {
            if (!item.Equals(value))
            {
                item = value;
                NotifyPropertyChanged(property);
            }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value, "PageTitle"); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, "IsBusy"); }
        }
    }
}

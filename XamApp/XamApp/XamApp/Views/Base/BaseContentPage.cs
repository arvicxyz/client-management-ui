using System;
using XamApp.ViewModels;
using Xamarin.Forms;

namespace XamApp.Views
{
    public class BaseContentPage<T> : ContentPage where T : BaseViewModel
    {
        public T ViewModel { get; private set; }

        public BaseContentPage()
        {
            var viewModel = Activator.CreateInstance<T>();
            viewModel.Page = this;
            viewModel.Navigation = Navigation;
            ViewModel = viewModel;
            BindingContext = viewModel;
        }
    }
}

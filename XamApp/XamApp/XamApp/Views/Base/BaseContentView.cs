using System;
using XamApp.ViewModels;
using Xamarin.Forms;

namespace XamApp.Views
{
    public class BaseContentView<T> : ContentView where T : BaseViewModel
    {
        protected T ViewModel { get; private set; }

        public BaseContentView()
        {
            var viewModel = Activator.CreateInstance<T>();
            viewModel.Page = Parent?.Parent as Page;
            viewModel.Navigation = Navigation;
            ViewModel = viewModel;
            BindingContext = viewModel;
        }
    }
}

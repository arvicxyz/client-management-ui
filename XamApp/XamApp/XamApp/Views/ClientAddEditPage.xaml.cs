using XamApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace XamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientAddEditPage : BaseContentPage<ClientAddEditPageViewModel>
    {
        public ClientAddEditPage()
        {
            InitializeComponent();
        }
    }
}

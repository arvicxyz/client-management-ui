using Xamarin.Forms;

namespace XamApp.Models.Interfaces
{
    public interface IBaseViewModel
    {
        Page Page { get; set; }

        INavigation Navigation { get; set; }
    }
}

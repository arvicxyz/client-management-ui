using UIKit;
using XamApp.iOS.Extensions;
using XamApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace XamApp.iOS.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            var searchbar = (UISearchBar)Control;

            if (e.NewElement != null)
            {
                Foundation.NSString searchField = new Foundation.NSString("searchField");
                var textField = (UITextField)searchbar.ValueForKey(searchField);
                textField.BackgroundColor = UIColor.Clear.FromHex(0xFFFFFF);
                //textField.TextColor = UIColor.White;

                //searchbar.TintColor = UIColor.White;
                //searchbar.BarTintColor = UIColor.White;
                //searchbar.Layer.CornerRadius = 0;
                //searchbar.Layer.BorderWidth = 12;
                //searchbar.Layer.BorderColor = UIColor.FromRGB(0, 73, 135).CGColor;
                //searchbar.Layer.BackgroundColor = UIColor.Blue.CGColor;

                searchbar.SetShowsCancelButton(false, true);
            }
        }
    }
}

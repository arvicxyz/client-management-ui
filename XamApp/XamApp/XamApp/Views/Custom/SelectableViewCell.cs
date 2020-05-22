using Xamarin.Forms;

namespace XamApp.Views.Custom
{
    public class SelectableViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedItemBackgroundColorProperty
            = BindableProperty.Create("SelectedItemBackgroundColor", typeof(Color), typeof(SelectableViewCell), GetSelectedDefaultColor());

        public Color SelectedItemBackgroundColor
        {
            get { return (Color)GetValue(SelectedItemBackgroundColorProperty); }
            set { SetValue(SelectedItemBackgroundColorProperty, value); }
        }

        private static Color GetSelectedDefaultColor()
        {
            Color color = (Color)Application.Current.Resources["SelectorColor"];
            return color;
        }
    }
}

using Xamarin.Forms;

namespace XamApp.Views.Custom
{
    public class FontAwesomeLabel : Label
    {
        public const string Typeface = "FontAwesome";

        public FontAwesomeLabel()
        {
            FontFamily = Typeface;
        }

        public FontAwesomeLabel(string fontAwesomeIcon = null)
        {
            Text = fontAwesomeIcon;
            FontFamily = Typeface;
        }
    }
}

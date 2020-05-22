using Android.Content;
using Android.Graphics;
using XamApp.Droid.Renderers;
using XamApp.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FontAwesomeLabel), typeof(FontAwesomeLabelRenderer))]
namespace XamApp.Droid.Renderers
{
    public class FontAwesomeLabelRenderer : LabelRenderer
    {
        public FontAwesomeLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
                Control.Typeface = Typeface.CreateFromAsset(Context.Assets, FontAwesomeLabel.Typeface + ".ttf");
        }
    }
}

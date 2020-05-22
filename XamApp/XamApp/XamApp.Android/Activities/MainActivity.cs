using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.CurrentActivity;

namespace XamApp.Droid.Activities
{
    [Activity(
        Icon = "@mipmap/icon",
        Label = "@string/app_name_string",
        Theme = "@style/Theme.Main",
        ScreenOrientation = ScreenOrientation.FullSensor,
        ConfigurationChanges = ConfigChanges.ScreenSize
        | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // Initializations
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU3ODAxQDMxMzgyZTMxMmUzMGcvc1NvZThBeXNaMU41aDVzREdrd0xyRHIvY09VSjBDeC9lQUx0OEZnSkk9");
            CrossCurrentActivity.Current.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Screen Size
            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;
            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                App.StatusBarHeight = (int)(Resources.GetDimensionPixelSize(resourceId) / Resources.DisplayMetrics.Density);
            }

            LoadApplication(new App());
        }
    }
}

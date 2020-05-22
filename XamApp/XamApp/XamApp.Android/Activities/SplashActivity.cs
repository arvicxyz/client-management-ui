using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace XamApp.Droid.Activities
{
    [Activity(
        Icon = "@mipmap/icon",
        Label = "@string/app_name_string",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.FullSensor,
        ConfigurationChanges = ConfigChanges.ScreenSize
        | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}

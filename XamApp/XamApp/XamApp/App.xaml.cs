using XamApp.Repositories;
using XamApp.Views.Custom;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamApp
{
    public partial class App : Application
    {
        public static float ScreenWidth { get; set; }
        public static float ScreenHeight { get; set; }
        public static double StatusBarHeight { get; set; }

        public static string AppName { get; private set; }
        public static AppRepository Repository { get; private set; }

        public App()
        {
            InitializeComponent();

            AppName = (string)Current.Resources["AppNameString"];
            Repository = new AppRepository();

            if (Device.RuntimePlatform == Device.iOS)
            {
                if (StatusBarHeight <= 0)
                {
                    if (Device.Idiom == TargetIdiom.Tablet)
                    {
                        // iPad
                        StatusBarHeight = 24;
                    }
                    else if (Device.Idiom == TargetIdiom.Phone)
                    {
                        // iPhone
                        if (DeviceInfo.Model == "iPhone 11" ||
                            DeviceInfo.Model == "iPhone 11 Pro" ||
                            DeviceInfo.Model == "iPhone 11 Pro Max" ||
                            DeviceInfo.Model == "iPhone X" ||
                            DeviceInfo.Model == "iPhone XR" ||
                            DeviceInfo.Model == "iPhone XS" ||
                            DeviceInfo.Model == "iPhone XS Max")
                        {
                            StatusBarHeight = 44;
                        }
                        else
                        {
                            StatusBarHeight = 20;
                        }
                    }
                }
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    // Android Tablet
                    StatusBarHeight = 0;
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    // Android Phone
                    StatusBarHeight = 0;
                }
            }

            var page = new CustomTabBar();
            MainPage = new NavigationPage(page)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#454758")
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

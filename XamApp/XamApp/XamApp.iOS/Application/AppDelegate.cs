using Foundation;
using UIKit;
using XamApp.iOS.Extensions;

namespace XamApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Set Toolbar Appearance
            UIColor colorPrimary = UIColor.Clear.FromHex(0x454758);
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = colorPrimary;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White
            });
            UINavigationBar.Appearance.ShadowImage = new UIImage();

            // Initializations
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU3ODAxQDMxMzgyZTMxMmUzMGcvc1NvZThBeXNaMU41aDVzREdrd0xyRHIvY09VSjBDeC9lQUx0OEZnSkk9");
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.XForms.iOS.Expander.SfExpanderRenderer.Init();

            // Screen Size
            App.ScreenWidth = (float)UIScreen.MainScreen.Bounds.Width;
            App.ScreenHeight = (float)UIScreen.MainScreen.Bounds.Height;
            App.StatusBarHeight = (int)UIApplication.SharedApplication.StatusBarFrame.Height;

            LoadApplication(new App());
            Syncfusion.XForms.iOS.Buttons.SfRadioButtonRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}

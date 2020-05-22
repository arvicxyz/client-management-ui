using System;
using UIKit;

namespace XamApp.iOS
{
    public class Application
    {
        public static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}

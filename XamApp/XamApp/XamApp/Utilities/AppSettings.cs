using Plugin.Settings;
using Plugin.Settings.Abstractions;
using XamApp.Models.Enums;

namespace XamApp.Utilities
{
    public static class AppSettings
    {
        private static ISettings Settings
        {
            get { return CrossSettings.Current; }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string SortKey = "sort_key";
        private static readonly int SortDefault = 1;

        #endregion

        public static string GeneralSettings
        {
            get { return Settings.GetValueOrDefault(SettingsKey, SettingsDefault); }
            set { Settings.AddOrUpdateValue(SettingsKey, value); }
        }

        public static int SortSettings
        {
            get { return Settings.GetValueOrDefault(SortKey, SortDefault); }
            set { Settings.AddOrUpdateValue(SortKey, value); }
        }
    }
}

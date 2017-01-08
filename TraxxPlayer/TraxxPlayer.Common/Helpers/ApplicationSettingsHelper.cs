using System.Diagnostics;
using Windows.Storage;

namespace TraxxPlayer.Common.Helpers
{
    public static class ApplicationSettingsHelper
    {
        /// <summary>
        /// Read local setting
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Requested local setting as object</returns>
        public static object ReadSettingsValue(string key)
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                Debug.WriteLine($"No saved settings for {key}");
                return null;
            }
            else
            {
                var value = ApplicationData.Current.LocalSettings.Values[key];
                Debug.WriteLine($"Saved setting for {key}: {value}");
                return value;
            }
        }
        /// <summary>
        /// Read and delete local setting
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Requested local setting as object</returns>
        public static object ReadResetSettingsValue(string key)
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                Debug.WriteLine($"No saved settings for {key}");
                return null;
            }
            else
            {
                var value = ApplicationData.Current.LocalSettings.Values[key];
                ApplicationData.Current.LocalSettings.Values.Remove(key);
                Debug.WriteLine($"Saved setting for {key}: {value}");
                return value;
            }
        }

        /// <summary>
        /// Save local setting
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveSettingsValue(string key, object value)
        {
            Debug.WriteLine("Saved setting " + key + " = " + (value == null ? "null" : value.ToString()));

            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                ApplicationData.Current.LocalSettings.Values.Add(key, value);
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values[key] = value;
            }
        }

    }
}

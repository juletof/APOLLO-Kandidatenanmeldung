using System.Configuration;

namespace ApolloDb
{
    public class WebConfigSettings
    {
        private static readonly AppSettingsReader _settingReader = new AppSettingsReader();

        public static string EmailDefaultFrom { get { return Get<string>("EmailDefaultFrom"); } }

        private static T Get<T>(string settingKey)
        {
            return (T)_settingReader.GetValue(settingKey, typeof(T));
        }
    }
}

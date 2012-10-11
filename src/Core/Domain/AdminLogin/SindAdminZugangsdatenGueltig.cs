using ApolloDb.Infrastructure;

namespace ApolloDb
{
    public class SindAdminZugangsdatenGueltig : IRegisterAsInstancePerLifetime
    {
        private readonly DbSettingsRepository _settingsRepository;

        public SindAdminZugangsdatenGueltig(DbSettingsRepository settingsRepository){
            _settingsRepository = settingsRepository;
        }

        public bool Ja(string userName, string password)
        {
            var settings = _settingsRepository.Get();

            if (string.IsNullOrEmpty(settings.AdminPassword) || string.IsNullOrEmpty(settings.AdminUsername.Trim()))
                return userName == "123" && password == "123";

            return
                settings.AdminPassword.Trim() == password.Trim() &&
                settings.AdminUsername.Trim() == userName.Trim();

        }
    }
}

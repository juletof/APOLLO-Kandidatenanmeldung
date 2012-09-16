using NHibernate;

namespace ApolloDb
{
    public class Login : IRegisterAsInstancePerLifetime
    {
        private readonly ISession _session;

        public Login(ISession session){
            _session = session;
        }

        public LoginResult Run(string emailAddresse, string password)
        {
            var kandidat = _session.QueryOver<Kandidat>()
                                   .Where(x => x.EmailAdresse == emailAddresse)
                                   .And(x => x.Passwort == HashPassword.Run(password))
                                   .SingleOrDefault<Kandidat>();

            if(kandidat == null)
                return new LoginResult{Success = false};

            return new LoginResult{Kandidat = kandidat, Success = true};
        }
    }
}

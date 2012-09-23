using System;
using NHibernate;

namespace ApolloDb
{
    public class PasswortResetVorbereiten : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly ISession _session;

        public PasswortResetVorbereiten(KandidatRepository kandidatRepository, ISession session)
        {
            _kandidatRepository = kandidatRepository;
            _session = session;
        }

        public PasswortResetVorbereitenResult Run(string token)
        {
            var passwortToken = _session.QueryOver<PasswortVergessenToken>()
                    .Where(x => x.Token == token)
                    .SingleOrDefault<PasswortVergessenToken>();

            if(passwortToken == null)
                return new PasswortResetVorbereitenResult{KeinTokenGefunden = true};

            if((DateTime.Now - passwortToken.DateCreated).TotalDays > 3)
                return new PasswortResetVorbereitenResult { TokenAelterAls72h = true };

            return new PasswortResetVorbereitenResult { Email = passwortToken.Email, Success = true};
        }
    }
}

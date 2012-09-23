using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class PasswortReset : IRegisterAsInstancePerLifetime
    {
        private readonly PasswortResetVorbereiten _passwortResetVorbereiten;
        private readonly KandidatRepository _kandidatRepository;

        public PasswortReset(PasswortResetVorbereiten passwortResetVorbereiten, KandidatRepository kandidatRepository)
        {
            _passwortResetVorbereiten = passwortResetVorbereiten;
            _kandidatRepository = kandidatRepository;
        }

        public bool Run(string token, string newPassword)
        {
            var passwortResetVorbereitenResult = _passwortResetVorbereiten.Run(token);
            if (!passwortResetVorbereitenResult.Success)
                return false;

            var kandidat = _kandidatRepository.GetByEmail(passwortResetVorbereitenResult.Email);
            kandidat.Passwort = HashPassword.Run(newPassword);
            _kandidatRepository.Update(kandidat);

            return true;
        }
    }
}

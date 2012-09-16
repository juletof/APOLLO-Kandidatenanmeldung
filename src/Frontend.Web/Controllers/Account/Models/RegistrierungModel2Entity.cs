using System;

namespace ApolloDb
{
    public class RegistrierungModel2Entity
    {
        public static Kandidat Run(RegistrierungModel model)
        {
            var praktikant = new Kandidat();
            praktikant.Geschlecht = Convert.ToInt32(model.AnredeVal);
            praktikant.FamiliennameKY = model.FamiliennameKY;
            praktikant.VornameKY = model.VornameKY;
            praktikant.VatersnameKY = model.VatersnameKY;
            praktikant.EmailAdresse = model.Emailadresse;
            praktikant.Passwort = HashPassword.Run(model.Passwort);

            return praktikant;
        }
    }
}
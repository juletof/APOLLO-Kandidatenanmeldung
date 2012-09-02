using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApolloDb
{
    public class RegistrierungModel2Entity
    {
        public static Praktikant Run(RegistrierungModel model)
        {
            var praktikant = new Praktikant();
            praktikant.Anrede = Convert.ToInt32(model.AnredeVal);
            praktikant.FamiliennameKY = model.FamiliennameKY;
            praktikant.VornameKY = model.VornameKY;
            praktikant.VatersnameKY = model.VatersnameKY;
            praktikant.EmailAdresse = model.Emailadresse;
            praktikant.Passwort = model.Passwort;

            return praktikant;
        }
    }
}
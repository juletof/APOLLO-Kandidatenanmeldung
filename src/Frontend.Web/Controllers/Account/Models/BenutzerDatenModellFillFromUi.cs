using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApolloDb
{
    public class BenutzerDatenModellFillFromUi
    {
        public static Kandidat Run(BenutzerDatenModel model, Kandidat kandidat)
        {
            kandidat.Geschlecht = Convert.ToInt32(model.AnredeVal);
            kandidat.FamiliennameKY = model.FamiliennameKY;
            kandidat.VornameKY = model.VornameKY;
            kandidat.VatersnameKY = model.VatersnameKY;
            kandidat.EmailAdresse = model.Emailadresse;

            return kandidat;
        }
    }
}
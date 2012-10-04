using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApolloDb;


public class DashboardModel
{
    public Message Message;

    public string VornameKY;
    public string NachnameKY;

    public string Nachname_Vorname_Vatersname;
    public string Email;
    public bool ZeigeRegistrierungErfolgreich;

    public KandidatStatus KandidatStatus;

    public DashboardModel(Kandidat kandidat)
    {
        VornameKY = kandidat.VornameKY;
        NachnameKY = kandidat.FamiliennameKY;

        Nachname_Vorname_Vatersname = kandidat.FamiliennameKY + " " + kandidat.VornameKY + " " + kandidat.VatersnameKY;

        Email = kandidat.EmailAdresse;
        KandidatStatus = kandidat.Status;
    }
}
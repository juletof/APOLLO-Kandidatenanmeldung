using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApolloDb;


public class DashboardModel
{
    public string VollerNameKY;
    public string Email;

    public KandidatStatus KandidatStatus;

    public DashboardModel(Kandidat kandidat)
    {
        VollerNameKY = kandidat.GetVollerNameKY();
        Email = kandidat.EmailAdresse;
        KandidatStatus = kandidat.Status;
    }
}
﻿using System;
using NHibernate;
using NHibernate.Criterion;

namespace ApolloDb
{
    public class StatusStatistikLaden : IRegisterAsInstancePerLifetime
    {
        private readonly ISession _session;

        public StatusStatistikLaden(ISession session){
            _session = session;
        }

        public StatusStatistikLadenResult Run(int uniId, int praktikumsJahr)
        {
            _session.Flush();

            var query = _session.QueryOver<Kandidat>()
                .Select(
                    Projections.Group<Kandidat>(k => k.Status),
                    Projections.Count<Kandidat>(k => k.Status)
                );

            if (uniId > 0)
                query.Where(k => k.Hochschule == uniId);
            
            if (praktikumsJahr > 0)
                query.Where(k => k.Praktikumsjahr == praktikumsJahr);


            var dbResults = query.List<object[]>();

            var result = new StatusStatistikLadenResult();
            foreach(var dbResult in dbResults)
            {
                if (((KandidatStatus)dbResult[0]) == KandidatStatus.Registriert){
                    result.Registriert = Convert.ToInt32(dbResult[1]); 
                    continue;
                }

                if (((KandidatStatus)dbResult[0]) == KandidatStatus.AnmeldungVollstaendig){
                    result.AnmeldungVollstaendig = Convert.ToInt32(dbResult[1]);
                    continue;
                }

                if (((KandidatStatus)dbResult[0]) == KandidatStatus.Zugelassen){
                    result.Zugelassen = Convert.ToInt32(dbResult[1]);
                    continue;
                }

                if (((KandidatStatus)dbResult[0]) == KandidatStatus.Ausgeschieden){
                    result.Ausgeschieden = Convert.ToInt32(dbResult[1]);
                    continue;
                }
                
                if (((KandidatStatus)dbResult[0]) == KandidatStatus.Auswahl1){
                    result.Auswahl1= Convert.ToInt32(dbResult[1]);
                    continue;
                }

                if (((KandidatStatus)dbResult[0]) == KandidatStatus.Auswahl2){
                    result.Auswahl2 = Convert.ToInt32(dbResult[1]);
                    continue;
                }
                
                if (((KandidatStatus)dbResult[0]) == KandidatStatus.Reserve){
                    result.Reserve = Convert.ToInt32(dbResult[1]);
                    continue;
                }
            }

            return result;
        }
    }
}

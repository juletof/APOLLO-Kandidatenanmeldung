using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    /// <summary>Initialisiert die Datenbank, nachdem die Statuswechsel Tabelle erstellt wird.</summary>
    public class StatuswechselInitialisieren : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly StatuswechselRepository _statuswechselRepository;

        public StatuswechselInitialisieren(
            KandidatRepository kandidatRepository, 
            StatuswechselRepository statuswechselRepository
            )
        {
            _kandidatRepository = kandidatRepository;
            _statuswechselRepository = statuswechselRepository;
        }

        public void Run()
        {
            var kandidaten = _kandidatRepository.GetAll();
            foreach(var kandidat in kandidaten)
            {
                _statuswechselRepository.Create(
                    new Statuswechsel
                        {
                            KandidatId = kandidat.Id,
                            Status = KandidatStatus.Registriert,
                            Zeitpunkt = kandidat.DateCreated
                        }
                    );

                if(kandidat.Status == KandidatStatus.AnmeldungVollstaendig)
                {
                    _statuswechselRepository.Create(
                        new Statuswechsel
                        {
                            KandidatId = kandidat.Id,
                            Status = KandidatStatus.AnmeldungVollstaendig,
                            Zeitpunkt = kandidat.DateModified
                        }
                    );
                }
            }
        }
    }
}
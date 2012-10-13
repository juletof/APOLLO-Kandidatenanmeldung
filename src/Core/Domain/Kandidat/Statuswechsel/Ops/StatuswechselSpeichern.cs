using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class StatuswechselSpeichern : IRegisterAsInstancePerLifetime
    {
        private readonly StatuswechselRepository _statuswechselRepository;

        public StatuswechselSpeichern(StatuswechselRepository statuswechselRepository){
            _statuswechselRepository = statuswechselRepository;
        }

        public void Run(int kandidatId, KandidatStatus kandidatStatus)
        {
            _statuswechselRepository.Create(
                new Statuswechsel
                    {
                        KandidatId = kandidatId,
                        Status = kandidatStatus,
                        Zeitpunkt = DateTime.Now
                    });
        }
    }
}
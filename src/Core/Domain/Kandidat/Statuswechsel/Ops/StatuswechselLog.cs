using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class StatuswechselLog : IRegisterAsInstancePerLifetime
    {
        private readonly StatuswechselRepository _statuswechselRepository;

        public StatuswechselLog(StatuswechselRepository statuswechselRepository){
            _statuswechselRepository = statuswechselRepository;
        }

        public void Run(int kandidatId, KandidatStatus neuerStatus)
        {
            _statuswechselRepository.Create(
                new Statuswechsel
                    {
                        KandidatId = kandidatId,
                        Status = neuerStatus,
                        Zeitpunkt = DateTime.Now
                    });
        }
    }
}
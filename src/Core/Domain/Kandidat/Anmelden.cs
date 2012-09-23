using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class Anmelden : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;

        public Anmelden(KandidatRepository kandidatRepository)
        {
            _kandidatRepository = kandidatRepository;
        }

        public void Run(Kandidat kandidat)
        {
            kandidat.Status = KandidatStatus.AnmeldungVollstaendig;
            _kandidatRepository.Update(kandidat);
        }
    }
}

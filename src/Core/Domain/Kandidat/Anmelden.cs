namespace ApolloDb
{
    public class Anmelden : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly StatuswechselLog _statuswechselLog;

        public Anmelden(KandidatRepository kandidatRepository, 
                        StatuswechselLog statuswechselLog)
        {
            _kandidatRepository = kandidatRepository;
            _statuswechselLog = statuswechselLog;
        }

        public void Run(Kandidat kandidat)
        {
            kandidat.Status = KandidatStatus.AnmeldungVollstaendig;
            
            _statuswechselLog.Run(kandidat.Id, kandidat.Status);
            _kandidatRepository.Update(kandidat);
        }
    }
}

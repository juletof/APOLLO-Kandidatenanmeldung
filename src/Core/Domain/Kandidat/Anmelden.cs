namespace ApolloDb
{
    public class Anmelden : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly StatuswechselSpeichern _statuswechselSpeichern;

        public Anmelden(KandidatRepository kandidatRepository, 
                        StatuswechselSpeichern statuswechselSpeichern)
        {
            _kandidatRepository = kandidatRepository;
            _statuswechselSpeichern = statuswechselSpeichern;
        }

        public void Run(Kandidat kandidat)
        {
            kandidat.Status = KandidatStatus.AnmeldungVollstaendig;
            
            _statuswechselSpeichern.Run(kandidat.Id, kandidat.Status);
            _kandidatRepository.Update(kandidat);
        }
    }
}

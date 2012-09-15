namespace ApolloDb
{
    public class Registrieren : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;

        public Registrieren(KandidatRepository kandidatRepository){
            _kandidatRepository = kandidatRepository;
        }

        public Kandidat Run(Kandidat kandidat)
        {
            kandidat.Status = KandidatStatus.Registriert;
            _kandidatRepository.Create(kandidat);
            return kandidat;
        }
    }
}

namespace ApolloDb
{
    public class KandidatLoeschen : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;

        public KandidatLoeschen(KandidatRepository kandidatRepository)
        {
            _kandidatRepository = kandidatRepository;
        }

        public void Run(int kandidatId)
        {
            _kandidatRepository.Delete(kandidatId);
        }
    }
}

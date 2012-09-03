namespace ApolloDb
{
    public class Registrieren : IRegisterAsInstancePerLifetime
    {
        private readonly PraktikantRepository _praktikantRepository;

        public Registrieren(PraktikantRepository praktikantRepository){
            _praktikantRepository = praktikantRepository;
        }

        public void Run(Praktikant praktikant)
        {
            praktikant.Status = PraktikantStatus.ErsteRegistrierung;
            _praktikantRepository.Create(praktikant);
        }
    }
}

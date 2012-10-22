namespace ApolloDb
{
    public class Statuswechseln : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly StatuswechselLog _statuswechselLog;

        public Statuswechseln(KandidatRepository kandidatRepository,
                              StatuswechselLog statuswechselLog)
        {
            _kandidatRepository = kandidatRepository;
            _statuswechselLog = statuswechselLog;
        }

        public void Run(int kandidatId, KandidatStatus neuerStatus)
        {
            var kandidat = _kandidatRepository.GetById(kandidatId);
            kandidat.Status = neuerStatus;
            _statuswechselLog.Run(kandidatId, neuerStatus);

            _kandidatRepository.Update(kandidat);
        }
    }
}

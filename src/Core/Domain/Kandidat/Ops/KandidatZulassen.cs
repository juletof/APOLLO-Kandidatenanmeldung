namespace ApolloDb
{
    public class KandidatZulassen : IRegisterAsInstancePerLifetime
    {
        private readonly Statuswechseln _statuswechseln;

        public KandidatZulassen(Statuswechseln statuswechseln){
            _statuswechseln = statuswechseln;
        }

        public void Run(int kandidatId){
            _statuswechseln.Run(kandidatId, KandidatStatus.Zugelassen);
        }
    }
}

namespace ApolloDb
{
    public class ZurReserve : IRegisterAsInstancePerLifetime
    {
        private readonly Statuswechseln _statuswechseln;

        public ZurReserve(Statuswechseln statuswechseln){
            _statuswechseln = statuswechseln;
        }

        public void Run(int kandidatId){
            _statuswechseln.Run(kandidatId, KandidatStatus.Reserve);
        }
    }
}

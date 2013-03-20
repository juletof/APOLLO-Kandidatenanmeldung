namespace ApolloDb
{
    public class ZurAuswahl1 : IRegisterAsInstancePerLifetime
    {
        private readonly Statuswechseln _statuswechseln;

        public ZurAuswahl1(Statuswechseln statuswechseln){
            _statuswechseln = statuswechseln;
        }

        public void Run(int kandidatId){
            _statuswechseln.Run(kandidatId, KandidatStatus.Auswahl1);
        }
    }
}

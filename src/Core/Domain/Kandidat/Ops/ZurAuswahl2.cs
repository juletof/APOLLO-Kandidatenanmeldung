namespace ApolloDb
{
    public class ZurAuswahl2 : IRegisterAsInstancePerLifetime
    {
        private readonly Statuswechseln _statuswechseln;

        public ZurAuswahl2(Statuswechseln statuswechseln){
            _statuswechseln = statuswechseln;
        }

        public void Run(int kandidatId){
            _statuswechseln.Run(kandidatId, KandidatStatus.Auswahl2);
        }
    }
}

namespace ApolloDb
{
    public class KandidatAusschliessen : IRegisterAsInstancePerLifetime
    {
        private readonly Statuswechseln _statuswechseln;

        public KandidatAusschliessen(Statuswechseln statuswechseln){
            _statuswechseln = statuswechseln;
        }

        public void Run(int kandidatId){
            _statuswechseln.Run(kandidatId, KandidatStatus.Ausgeschieden);
        }
    }
}

using Seedworks.Web.State;

namespace ApolloDb
{
    public class SessionUser : SessionBase, IRegisterAsInstancePerLifetime
    {
        public bool IsLoggedIn
        {
            get { return Data.Get<bool>("isLoggedIn", false); }
            private set { Data["isLoggedIn"] = value; }
        }

        public Kandidat Kandidat
        {
            get { return Data.Get<Kandidat>("kandidat"); }
            private set { Data["kandidat"] = value; }
        }

        public void Login(Kandidat kandidat)
        {
            IsLoggedIn = true;
            Kandidat = kandidat;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            Kandidat = null;
        }
    }
}

using System;
using Seedworks.Web.State;

namespace ApolloDb
{
    public class SessionUser : SessionBase, IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;

        public SessionUser(KandidatRepository kandidatRepository)
        {
            _kandidatRepository = kandidatRepository;
        }

        public bool IsLoggedIn
        {
            get { return Data.Get("isLoggedIn", false); }
            private set { Data["isLoggedIn"] = value; }
        }

        public int KandidatId
        {
            get { return (int) Data.Get("kandidatId"); }
            private set { Data["kandidatId"] = value; }
        }

        public Kandidat GetKandidat()
        {
            return _kandidatRepository.GetById(KandidatId);
        }

        public void Login(Kandidat kandidat)
        {
            IsLoggedIn = true;
            KandidatId = kandidat.Id;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            KandidatId = -1;
        }
    }
}

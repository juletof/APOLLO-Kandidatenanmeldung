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

        public bool IsLoggedInKandidat
        {
            get { return Data.Get("isLoggedInKandidat", false); }
            private set { Data["isLoggedInKandidat"] = value; }
        }

        public bool IsLoggedAdmin
        {
            get { return Data.Get("isLoggedAdmin", false); }
            private set { Data["isLoggedAdmin"] = value; }
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
            IsLoggedInKandidat = true;
            KandidatId = kandidat.Id;
        }

        public void LoginAsAdmin()
        {
            IsLoggedAdmin = true;
        }

        public void Logout()
        {
            IsLoggedInKandidat = false;
            KandidatId = -1;
        }

        public void LogoutAdmin()
        {
            IsLoggedAdmin = false;
        }

    }
}

using ApolloDb.Infrastructure;
using NHibernate;

namespace ApolloDb.Updates
{
    public class UpdateToVs008
    {
        public static void Run()
        {
            var kandiRepo = Sl.Resolve<KandidatRepository>();
            var kandis = kandiRepo.GetAll();
            NamensBereiniger.Run(kandis);
            kandiRepo.Update(kandis);
        }
    }
}
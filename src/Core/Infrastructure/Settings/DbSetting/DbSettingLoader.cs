using System;
using NHibernate;
using Seedworks.Lib.Persistence;

namespace ApolloDb.Infrastructure
{
    public class DbSettingsRepository : RepositoryDb<DbSettings>
    {
        public DbSettingsRepository(ISession session)
            : base(session)
        {
        }

        public DbSettings Get()
        {
            return base.GetById(1);
        }

        public void UpdateAppVersion(int newAppVersion)
        {
            if(newAppVersion == 2)
            {
                base.Create(new DbSettings {AppVersion = newAppVersion});
                return;
            }

            var dbSettings = Get();
            dbSettings.AppVersion = newAppVersion;
            base.Update(dbSettings);
            base.Flush();
        }

        public int GetAppVersion()
        {
            var sqlResult = _session.CreateSQLQuery("select AppVersion from Setting").UniqueResult();
            if (sqlResult == null)
                return 0;

            return Convert.ToInt32(sqlResult);
        }
    }
}

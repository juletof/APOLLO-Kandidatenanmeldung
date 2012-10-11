using Seedworks.Lib.Persistence;

namespace ApolloDb.Infrastructure
{
    public class DbSettings : DomainEntity
    {
        public virtual int AppVersion { get; set; }
        public virtual string AdminUsername { get; set; }
        public virtual string AdminPassword { get; set; }        
    }
}
using System;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class Statuswechsel : DomainEntity
    {
        public virtual int KandidatId { get; set; }
        public virtual KandidatStatus Status { get; set; }
        public virtual DateTime Zeitpunkt { get; set; }
    }
}

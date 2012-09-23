using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class PasswortVergessenToken :  DomainEntity
    {
        public virtual string Token { get; set; }
        public virtual string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class PasswortResetVorbereitenResult
    {
        public bool KeinTokenGefunden;
        public bool TokenAelterAls72h;

        public string Email;
        public bool Success;
    }
}

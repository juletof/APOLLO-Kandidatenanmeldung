using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class GetOverwrittenConnectionStringResult
    {
        public GetOverwrittenConnectionStringResult(bool hasValue, string value)
        {
            HasValue = hasValue;
            Value = value;
        }

        public bool HasValue;
        public string Value;
    }
}

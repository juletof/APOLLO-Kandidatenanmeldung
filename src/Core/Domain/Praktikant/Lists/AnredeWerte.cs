using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class AnredeWerte : ListBase
    {        
        static AnredeWerte()
        {
            _items.Add(new ListItem(1, "Herr"));
            _items.Add(new ListItem(2, "Frau"));
        }

    }
}

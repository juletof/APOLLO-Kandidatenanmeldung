using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class Studienfaecher : ListBase
    {
        public Studienfaecher()
        {
            _items.Add(new ListItem(1, deutsch: "Studienfach-1", russisch: "Studienfache-KY-1"));
            _items.Add(new ListItem(2, deutsch: "Studienfach-2", russisch: "Studienfach-KY-2"));
        }
    }
}

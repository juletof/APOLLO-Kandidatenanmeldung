using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb.Domain.Kandidat.Lists
{
    public class Studienjahr : ListBase
    {
        public Studienjahr()
        {
            _items.Add(new ListItem(1, deutsch: "3.verkürzt", russisch: "3.verkürzt-KY-1"));
            _items.Add(new ListItem(2, deutsch: "4.verkürzt", russisch: "4.verkürzt-KY-2"));            
        }
    }
}

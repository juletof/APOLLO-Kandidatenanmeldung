using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class Universitaeten : ListBase
    {
        static Universitaeten()
        {
            _items.Add(new ListItem(1, deutsch: "Uni-1", russisch:"Uni-1"));
            _items.Add(new ListItem(2, deutsch: "Uni-2", russisch: "Uni-2"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class Abschluesse : ListBase
    {
        public Abschluesse()
        {
            _items.Add(new ListItem(1, deutsch: "Diplom", russisch: "Übersetzung"));
            _items.Add(new ListItem(2, deutsch: "Bachelor", russisch: "Übersetzung"));
            _items.Add(new ListItem(2, deutsch: "Magister", russisch: "Übersetzung"));
            _items.Add(new ListItem(2, deutsch: "Aspirantur", russisch: "Übersetzung"));
            _items.Add(new ListItem(2, deutsch: "Sonstiges", russisch: "Übersetzung"));
        }
    }
}

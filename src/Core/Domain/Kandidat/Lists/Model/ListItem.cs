using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class ListItem
    {
        public int Key;
        public string Deutsch;
        public string Russisch;

        public ListItem(int key, string deutsch = "", string russisch = "")
        {
            Key = key;
            Deutsch = deutsch;
            Russisch = russisch;
        }
    }
}

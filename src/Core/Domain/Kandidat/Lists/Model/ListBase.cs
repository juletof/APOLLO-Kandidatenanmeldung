using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ApolloDb
{
    public class ListBase
    {
        protected static IList<ListItem> _items = new List<ListItem>();
        protected const int _defaultKey = -1;

        public static IList<SelectListItem> ToSelectItems()
        {
            return 
                _items.Select(x => new SelectListItem
                    {
                        Selected = x.Key == _defaultKey,
                        Text = x.Deutsch,
                        Value = x.Key.ToString()
                    }).ToList();
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ApolloDb
{
    public class ListBase
    {
        protected IList<ListItem> _items = new List<ListItem>();

        public IList<SelectListItem> ToSelectItems(int studienfach)
        {
            return 
                _items.Select(x => new SelectListItem
                    {
                        Selected = x.Key == studienfach,
                        Text = x.Deutsch + " | " + x.Russisch,
                        Value = x.Key.ToString()
                    }).ToList();
        }

        public IList<SelectListItem> ToSelectItems()
        {
            return ToSelectItems(-1);
        }

        protected void Add(int index, string de, string ru)
        {
            _items.Add(new ListItem(index, deutsch: de, russisch: ru));
        }

        public ListItem ById(int itemId)
        {
            return _items.ToList().Find(x => x.Key == itemId);
        }

        public string GermanLabel(int itemId, string emptyLabel)
        {
            var result = ById(itemId);
            if (result == null)
                return emptyLabel;

            return result.Deutsch;
        }
    }
}

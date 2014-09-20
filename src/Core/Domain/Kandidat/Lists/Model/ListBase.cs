using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ApolloDb
{
    public class ListBase
    {
        protected IList<ListItem> _items = new List<ListItem>();

        public IList<SelectListItem> ToSelectItems(int selectedItem, bool onlyActive = false)
        {
            Func<ListItem, bool> isSelectedItem = li => li.Key == selectedItem;

            return 
                _items
                .Where(x => !onlyActive || x.IstAktiv || isSelectedItem(x))
                .Select(x => new SelectListItem
                    {
                        Selected = isSelectedItem(x),
                        Text = x.Deutsch + " | " + x.Russisch,
                        Value = x.Key.ToString()
                    }).ToList();
        }

        public IList<SelectListItem> ToSelectItems(bool onlyActive = false)
        {
            return ToSelectItems(-1, onlyActive);
        }

        public IEnumerable<ListItem> GetItems(){
            return _items;
        }

        protected void Add(int index, string de, string ru, bool istAktiv = true)
        {
            _items.Add(new ListItem(index, deutsch: de, russisch: ru, istAktiv: istAktiv));
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

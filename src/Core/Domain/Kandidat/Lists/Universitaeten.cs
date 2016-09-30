﻿using System.Linq;

namespace ApolloDb
{
    public class Universitaeten : ListBase
    {
        public Universitaeten()
        {
            Add(1,"Astrachan", "Астраханский государственный университет", istAktiv: false);
            Add(2,"Ufa","Башкирский государственный аграрный университет");
            Add(3,"Brjansk","Брянская государственная сельскохозяйственная академия", istAktiv: false);
            Add(14, "Voronezh", "Воронежский государственный аграрный университет императора Петра I");
            Add(4, "Kirov", "Вятская государственная сельскохозяйственная академия");
            Add(5, "Ivanovo", "Ивановская государственная сельскохозяйственная академия имени академика Д.К.Беляева", istAktiv: false);
            Add(6, "Izhewsk", "Ижевская государственная сельскохозяйственная академия", istAktiv: false);
            Add(18, "Kazan Vet-Akademie", "Казанская государственная академия ветеринарной медицины имени Н.Э. Баумана");
            Add(7, "Kazan Universität", "Kазанский гоударственный аграрный университет");
            Add(15, "Kaliningrad", "Калининградский филиал Санкт-Петербургского аграрного университета", istAktiv: false);
            Add(8, "Knjaginino", "Нижегородский государственный инжениерно-экономический институт");
            Add(16, "Orel", "Орловский государственный аграрный университет");
            Add(9, "Penza", "Пензенская государственная сельскохозяйственная академия");
            Add(10,"Saratov","Саратовский государственный аграрный университет им. Н.И. Вавилова");
            Add(11,"Smolensk","Смоленская государственная сельскохозяйственная академия");
            Add(12,"Stavropol", "Ставропольский государственный аграрный университет");
            Add(13,"Ekaterinburg", "Уральский государственный аграрный университет");
            Add(17, "Tscheljabinsk", "Южно-Уральский государственный аграрный университет (Челябинск)", istAktiv: false);
        }

        public static string ToHtmlList(bool russian = false, bool onlyActive = true)
        {
            var listInner = russian ?
                            new Universitaeten().Items
                                .Where(x => !onlyActive || x.IstAktiv)
                                .Select(x => x.Russisch)
                                //.Aggregate((a, b) => a + "</br>" + b);
                                .Aggregate((a, b) => a + "</li><li>" + b) :
                            new Universitaeten().Items
                                .Where(x => !onlyActive || x.IstAktiv)
                                .Select(x => x.Deutsch)
                                //.Aggregate((a, b) => a + "</br>" + b);
                                .Aggregate((a, b) => a + "</li><li>" + b);
            
            return "<ul><li>" + listInner + "</li></ul>";

        }
    }
}

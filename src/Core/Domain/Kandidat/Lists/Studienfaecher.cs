using System.Collections.Generic;
using System.Web.Mvc;

namespace ApolloDb
{
    public class Studienfaecher : ListBase
    {
        public Studienfaecher()
        {
            Add(1, "Pflanzenbau", "Агрономия");
            Add(2, "Veterinärmedizin", "Ветернарная медицина");
            Add(3, "Bodenkataster", "Земельный кадастр");
            Add(4, "Tierhaltung", "Зоотехния");
            Add(5, "Mechanisierung", "Механизация");
            Add(6, "Verarbeitung", "Переработка");
            Add(7, "Ökonomie", "Экономика и бухгалтерия");
            Add(8, "Elektrifizierung", "Электрификация");
            Add(9, "sonstige", "другое");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ApolloDb;

public class PraktikantenModel
{
    public IList<PraktikantItemModel> Items;

    public PraktikantenModel(IEnumerable<Kandidat> praktikanten)
    {
        Items = praktikanten.Select(item => new PraktikantItemModel
            {
                Id = item.Id,
                Email = item.EmailAdresse,
                Geburtstag = item.Geburtsdatum == null ? 
                                "??.??.???" :
                                ((DateTime)item.Geburtsdatum).ToString("dd.mm.yyyy") + "(" + item.GetAlter() + ")",
                VollerName = item.GetVollerName(),
                VollerNameKY = item.GetVollerNameKY(),
                Hochschule = "---",
                Mobilnummer = "---",
                Studienfach = "---"

            }).ToList();
    }
}

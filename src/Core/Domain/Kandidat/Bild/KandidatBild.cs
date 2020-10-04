using System.IO;
using System.Web;
using ApolloDb;
using NHibernate.Util;

public class KandidatBild
{
    private static string _imagePath => HttpContext.Current.Server.MapPath("~/Images/");

    public static void Speichern(HttpPostedFileBase foto, Kandidat kandidat)
    {
        AlleLoeschen(kandidat);

        var fileInfo = new FileInfo(foto.FileName);
        var path = Path.Combine(_imagePath, kandidat.Id + fileInfo.Extension);
        foto.SaveAs(path);
    }

    private static void AlleLoeschen(Kandidat kandidat)
    {
        string[] dirs = Directory.GetFiles(_imagePath, $"{kandidat.Id}*");

        foreach (var dir in dirs)
            File.Delete(dir);
    }

    public static string Url(Kandidat kandidat)
    {
        string[] dirs = Directory.GetFiles(_imagePath, $"{kandidat.Id}*");

        if (dirs.Any())
        {
            var fileInfo = new FileInfo(dirs[0]);
            return $"/Images/{fileInfo.Name}";
        }

        return "#";
    }
}

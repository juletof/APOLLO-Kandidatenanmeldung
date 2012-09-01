using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Xml.Linq;
using Seedworks.Web.State;

namespace ApolloDb
{
    public class GetOverwrittenConnectionString
    {
        public static GetOverwrittenConnectionStringResult Run()
        {
            string filePath;
            if (ContextUtil.IsWebContext)
                filePath = HttpContext.Current.Server.MapPath(@"~/Web.overwritten.config");
            else
                filePath = Path.Combine(AssemblyDirectory, "App.overwritten.config");

            if (!File.Exists(filePath))
                return new GetOverwrittenConnectionStringResult(false, null);

            var xDoc = XDocument.Load(filePath);
            var value = xDoc.Root.Element("connectionString").Value;

            return new GetOverwrittenConnectionStringResult(true, value);
        }

        static private string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}

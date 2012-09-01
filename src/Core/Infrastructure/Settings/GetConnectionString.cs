using System.Configuration;

namespace ApolloDb
{
    public class GetConnectionString
    {
        public static string Run()
        {
            var result = GetOverwrittenConnectionString.Run();
            if (result.HasValue)
                return result.Value;

            return ConfigurationManager.ConnectionStrings["main"].ConnectionString;
        }
    }
}

namespace ApolloDb.Infrastructure
{
    public class ScriptPath
    {
        public static string Get(string fileName)
        {
            return "Utilities/Update/Scripts/" + fileName;
        }
    }
}

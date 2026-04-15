using SevenTV.Clients;
using System.Reflection;

namespace SevenTV
{
    public class SevenTVClient
    {
        public RestClient rest;
        public GraphQLClient graphql;
        
        public SevenTVClient(string? token = null, string? userAgent = null)
        {
            if (string.IsNullOrEmpty(userAgent))
            {
                string version = Assembly.GetExecutingAssembly()
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                    .InformationalVersion ?? "1.0.0";
                userAgent = $"SevenTV-lib/{version.Split("+")[0]}";
            }

            rest = new RestClient(token, userAgent);
            graphql = new GraphQLClient(token, userAgent);
        }
    }
}

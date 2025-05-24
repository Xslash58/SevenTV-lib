using SevenTV.Clients;

namespace SevenTV
{
    public class SevenTVClient
    {
        public RestClient rest;
        public GraphQLClient graphql;
        
        public SevenTVClient(string? token = null)
        {
            rest = new RestClient(token);
            graphql = new GraphQLClient(token);
        }
    }
}

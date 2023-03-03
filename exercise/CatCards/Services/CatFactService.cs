using CatCards.Models;
using RestSharp;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        private static readonly string API_URL = "https://cat-data.netlify.app/api/facts/random";
        private readonly RestClient client = new RestClient();

        public CatFact GetFact()
        {
            throw new System.NotImplementedException();
        }
    }
}

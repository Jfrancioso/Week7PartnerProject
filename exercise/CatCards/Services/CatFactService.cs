using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        private static readonly string API_URL = "https://cat-data.netlify.app/api/facts/random";
        private readonly RestClient client = new RestClient();

        public CatFact GetFact()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatFact> response = client.Get<CatFact>(request);

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"There was an error in the call to the server");
            }
            return response.Data;
        }
    }
}


using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        private static readonly string API_URL = "https://cat-data.netlify.app/api/pictures/random";
        private readonly RestClient client = new RestClient();

        public CatPic GetPic()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatPic> response = client.Get<CatPic>(request);

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"There was an error in the call to the server");
            }
            return response.Data;
        }
    }
}

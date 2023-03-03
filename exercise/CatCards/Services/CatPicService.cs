using CatCards.Models;
using RestSharp;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        private static readonly string API_URL = "https://cat-data.netlify.app/api/pictures/random";
        private readonly RestClient client = new RestClient();

        public CatPic GetPic()
        {
            throw new System.NotImplementedException();
        }
    }
}

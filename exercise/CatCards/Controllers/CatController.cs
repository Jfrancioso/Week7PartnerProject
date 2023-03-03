using System;
using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("/api/cards/")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatCardDao cardDao;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CatController(ICatCardDao _cardDao, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDao = _cardDao;
        }


        [HttpGet("{id}")]
        public ActionResult<CatCard> GetCard(int id)
        {
            CatCard card = cardDao.GetCard(id);
            if (card != null)
            {
                return Ok(card);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("random")]
        public ActionResult <CatCard> GetRandomCard()
        {
            CatPic randomPic = catPicService.GetPic();

            CatFact randomFact = catFactService.GetFact();

            CatCard randomCard = new CatCard();

            randomCard.CatFact = randomFact.Text;
            randomCard.ImgUrl = randomPic.File;

            
            if (randomCard != null)
            {
                return Ok(randomCard);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]

        public ActionResult<CatCard> SavedCatCard(CatCard cardToSave)
        {

            return cardDao.SaveCard(cardToSave);
        }

    }
}

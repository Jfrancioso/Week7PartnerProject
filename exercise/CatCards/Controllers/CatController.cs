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

        [HttpGet]
        public ActionResult<List<CatCard>> GetAllCards()
        {
            List<CatCard> cards = cardDao.GetAllCards();

            if (cards.Count == 0)
            {
                return NoContent();
            }
            return cards;

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
        public ActionResult<CatCard> GetRandomCard()
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

        [HttpPut("{id}")]
        public ActionResult UpdateCard(CatCard card)
        {
            bool updateSuccessful = cardDao.UpdateCard(card);

            if (updateSuccessful)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCard(int id)
        {
            bool updateSuccessful = cardDao.RemoveCard(id);

            if (updateSuccessful)
            {
                return NoContent();
            }
            return StatusCode(500);
        }
    }
}

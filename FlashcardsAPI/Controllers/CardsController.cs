using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashcardsAPI.Infrastcuture;
using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashcardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {

        private readonly FlashcardContext _context;

        public CardsController(FlashcardContext context) => _context = context;

        //GET:/api/cards - get all cards
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetCards()
        {
            return _context.Cards;
        }

        //GET:/api/cards/5 - get specific card
        [HttpGet("{id}")]
        public ActionResult<Card> GetCard(int id)
        {
            var card = _context.Cards.Find(id);

            if (card == null)
                return NotFound();

            return card;
        }

        [HttpGet("{id}/cards")]
        public ActionResult<IEnumerable<Card>> GetDeckCards(int id)
        {
            var deck = _context.Decks.Find(id);

            if (deck == null)
            {
                return NotFound();
            }

            var cards = _context.Cards.Where(c => c.DeckId == id);
            if (cards == null)
            {
                return NotFound();
            }

            return Ok(cards);
        }

        //POST: /api/cards - post new card
        [HttpPost]
        public ActionResult<Card> CreateCard(Card card)
        {
            _context.Cards.Add(card);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCard", new Card { Id = card.Id }, card);
        }

        //To write: PUT and DELETE

    }
}
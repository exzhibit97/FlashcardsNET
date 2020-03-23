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
    public class DecksController : ControllerBase
    {
        private readonly FlashcardContext _context;

        public DecksController(FlashcardContext context)
        {
            _context = context;
        }

        //GET:/api/cards - get all cards
        [HttpGet]
        public ActionResult<IEnumerable<DeckDTO>> GetDecks()
        {
            return _context.Decks;
        }

        
        [HttpGet("{id}")]
        public ActionResult<DeckDTO> GetDeck(int id)
        {
            var deck = _context.Decks.Find(id);

            if (deck == null)
            {
                return NotFound();
            }

            return deck;
        }

        //GET:/api/decks/5/cards - get specific card
        [HttpGet("{id}/cards")]
        public ActionResult<IEnumerable<CardDTO>> GetDeckCards(int id)
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

        [HttpPost]
        public ActionResult<DeckDTO> CreateDeck(DeckDTO deck)
        {
            _context.Decks.Add(deck);
            _context.SaveChanges();

            return CreatedAtAction("GetDeck", new CardDTO { Id = deck.Id }, deck);
        }



    }
}
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
        public ActionResult<IEnumerable<Deck>> GetDecks()
        {
            return _context.Decks;
        }

        
        [HttpGet("{id}")]
        public ActionResult<Deck> GetDeck(int id)
        {
            var deck = _context.Decks.Find(id);

            if (deck == null)
            {
                return NotFound();
            }

            return deck;
        }        

        [HttpPost]
        public ActionResult<Deck> CreateDeck(Deck deck)
        {
            _context.Decks.Add(deck);
            _context.SaveChanges();

            return CreatedAtAction("GetDeck", new Card { Id = deck.Id }, deck);
        }



    }
}
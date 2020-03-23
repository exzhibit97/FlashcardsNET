using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashcardsAPI.Infrastcuture;
using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<CardDTO>> GetCards()
        {
            return _context.Cards;
        }

        //GET:/api/cards/5 - get specific card
        [HttpGet("{id}")]
        public ActionResult<CardDTO> GetCard(int id)
        {
            var card = _context.Cards.Find(id);

            if (card == null)
                return NotFound();

            return card;
        }        

        //POST: /api/cards - post new card
        [HttpPost]
        public ActionResult<CardDTO> CreateCard(CardDTO card)
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

            return CreatedAtAction("GetCard", new CardDTO { Id = card.Id }, card);
        }

        [HttpPut("{id}")]
        public ActionResult<CardDTO> PutCard(int id, CardDTO card)
        {
            if (id != card.Id )
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult<CardDTO> DeleteCard(int id)
        {
            var card = _context.Cards.Find(id);

            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            _context.SaveChanges();

            return card;
        }

        //To write:DELETE!!!

    }
}
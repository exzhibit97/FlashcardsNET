using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAPI.Models
{
    public class Deck
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public List<Flashcard> Flashcards { get; set; }
    }
}

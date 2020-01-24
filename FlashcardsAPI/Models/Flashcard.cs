using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAPI.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string CardFront { get; set; }
        public string CardBack { get; set; }
        public string CardDescription { get; set; }

        public Flashcard() { }

    }
}

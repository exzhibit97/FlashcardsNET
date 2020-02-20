using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAPI.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();

        public Deck() { }

    }
}

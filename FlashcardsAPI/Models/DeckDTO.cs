using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAPI.Models
{
    public class DeckDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CardDTO> Cards { get; set; } = new List<CardDTO>();
    }
}

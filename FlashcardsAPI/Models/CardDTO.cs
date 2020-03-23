using Newtonsoft.Json;

namespace FlashcardsAPI.Models
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string CardFront { get; set; }
        public string CardBack { get; set; }
        public string CardDescription { get; set; }        
        public int DeckId { get; set; }
    }
}

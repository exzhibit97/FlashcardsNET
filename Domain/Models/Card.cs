
namespace Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string CardFront { get; set; }
        public string CardBack { get; set; }
        public string CardDescription { get; set; }
        public Deck Deck { get; set; }
        public int DeckId { get; set; }

        public Card(int id, string front, string back, int deckid)
        {
            Id = id;
            CardFront = front;
            CardBack = back;
            DeckId = deckid;
        }

    }
}

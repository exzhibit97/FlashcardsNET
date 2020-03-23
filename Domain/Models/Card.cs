
namespace Domain.Models
{
    public class Card
    {
        public int Id { get; }
        public string CardFront { get; private set; }
        public string CardBack { get; private set; }
        public string CardDescription { get; private set; }
        public Deck Deck { get; private set; }
        public int DeckId { get;}

        public Card(int id, string front, string back, int deckid)
        {
            Id = id;
            CardFront = front;
            CardBack = back;
            DeckId = deckid;
        }

        public void ChangeCardFront(string newCardFront)
        {
            CardFront = newCardFront;
        }

    }
}

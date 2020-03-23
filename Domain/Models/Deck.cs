using Domain.Models;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Deck
    {
        public int Id { get;}
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();

        public Deck(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        } 

        public void DeleteCard(Card card)
        {
            Cards.Remove(card);
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }


    }
}

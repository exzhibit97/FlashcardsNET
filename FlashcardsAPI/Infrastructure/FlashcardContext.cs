using Domain.Models;
using FlashcardsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAPI.Infrastcuture
{
    public class FlashcardContext : DbContext
    {
        public FlashcardContext(DbContextOptions<FlashcardContext> options) : base (options)
        {

        }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }

    }
}

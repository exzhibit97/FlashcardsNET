using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Container
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public HashSet<Card> Cards { get; set; } = new HashSet<Card>();

        public Container(int size)
        {
            Size = size;
        }

        
    }
}

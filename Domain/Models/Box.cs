
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Box
    {
        public int Id { get; set; }
        public ICollection<Container> Containers { get; set; } = new List<Container>();

        public Box()
        {

        }

    }
}

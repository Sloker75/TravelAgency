using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Duration { get; set; } // тривалість
        public double Price { get; set; }
        public string TypeTransport { get; set; }
        public int CountPeople { get; set; }

        public List<Comment> Comments { get; set; }
        public HotelAddress Address { get; set; }
        public List<Excursion> Excursions { get; set; }

    }
}

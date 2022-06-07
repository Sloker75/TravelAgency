using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ViewModels
{
    public class TourViewModel
    {
        //Tour

        public string Duration { get; set; } // тривалість
        public double Price { get; set; }
        public string TypeTransport { get; set; }
        public int CountPeople { get; set; }
        public int TourRating { get; set; }
        public bool IsHotTour { get; set; }

        //Hotel

        public string Name { get; set; }
        public string Description { get; set; }
        public int HotelRating { get; set; }
        public string TypeFood { get; set; }
        public string TypeBeach { get; set; }

        //HotelAddress

        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}

namespace Domain.Models
{
    public class Tour
    {
        public Tour()
        {
            Comments = new List<Comment>();
            Excursions = new List<Excursion>();
            Reserves = new List<Reserve>();
        }
        public int Id { get; set; }
        public string Duration { get; set; } // тривалість
        public double Price { get; set; }
        public string TypeTransport { get; set; }
        public int CountPeople { get; set; }
        public int Rating { get; set; }
        public bool IsHotTour { get; set; }
        public int EmployeeId { get; set; }
        public int? HotelId { get; set; }


        public List<Comment> Comments { get; set; }
        public Hotel Hotel { get; set; }
        public List<Excursion> Excursions { get; set; }
        public List<Reserve> Reserves { get; set; }
        public Employee Employee { get; set; }


    }
}

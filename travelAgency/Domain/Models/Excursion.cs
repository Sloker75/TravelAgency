namespace Domain.Models
{
    public class Excursion
    {
        public Excursion()
        {
            ShowPlaces = new List<ShowPlace>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ExcursionTime { get; set; }
        public int TourId { get; set; }
        public int ShowPlaceId { get; set; }

        public Tour Tour { get; set; }
        public List<ShowPlace> ShowPlaces { get; set; }
    }
}

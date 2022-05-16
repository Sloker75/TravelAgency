namespace Domain.Models
{
    public class Reserve
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }

        public User User { get; set; }
        public Tour Tour { get; set; }
    }
}

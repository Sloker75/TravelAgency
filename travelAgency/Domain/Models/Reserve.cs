namespace Domain.Models
{
    public class Reserve
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }

        public User UserReserve { get; set; }
        public Tour TourReserve { get; set; }
    }
}

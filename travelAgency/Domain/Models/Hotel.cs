namespace Domain.Models
{
    public class Hotel
    {
        public Hotel()
        {
            PhotoPath = new List<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string TypeFood { get; set; }
        public string TypeBeach { get; set; }
        public int HotelAddressId { get; set; }


        public List<Image> PhotoPath { get; set; }
        public HotelAddress HotelAddress { get; set; }

    }
}

namespace Domain.Models
{
    public class ShowPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Image> PhotoPath { get; set; }
        public Excursion Excursion { get; set; }
    }
}

﻿namespace Domain.Models
{
    public class ShowPlace
    {
        public ShowPlace()
        {
            PhotoPath = new List<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PhotoPathId { get; set; }
        public int ExcursionId { get; set; }

        public List<Image> PhotoPath { get; set; }
        public Excursion Excursion { get; set; }
    }
}

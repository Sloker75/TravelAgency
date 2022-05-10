using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Excursion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ExcursionTime { get; set; }

        public List<Tour> Tours { get; set; }
        public int MyProperty { get; set; }
    }
}

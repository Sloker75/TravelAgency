using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }

        public List<Reserve> Reserves { get; set; }
        public Employee Employee { get; set; }
    }
}

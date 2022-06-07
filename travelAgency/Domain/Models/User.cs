using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Reserves = new List<Reserve>();
        }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public int? EmployeeId { get; set; }

        public List<Reserve> Reserves { get; set; }
        public Employee Employee { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

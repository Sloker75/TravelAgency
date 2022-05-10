using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public DateTime SendingTime { get; set; }

        public User UserComment { get; set; }
        public Tour Tour { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string TypeFood { get; set; }
        public string TypeBeach { get; set; }
        public List<string> PhotoPath { get; set; }

        public HotelAddress HotelAddress { get; set; }

    }
}

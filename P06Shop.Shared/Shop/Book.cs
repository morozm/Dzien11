﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Shop
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public int Rate { get; set; }
        public string Genre { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}

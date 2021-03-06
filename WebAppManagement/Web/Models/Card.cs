﻿using System;

namespace Web.Models
{
    public class Card
    {
        public Guid cardId { get; set; }
        public string AuthToken { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
    }
}

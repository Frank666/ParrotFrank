﻿using System;
using System.Collections.Generic;

namespace ParrotFrankAPI.parrot_frank
{
    public partial class Subcategories
    {
        public int SubCategoryId { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
    }
}

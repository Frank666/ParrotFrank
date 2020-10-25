using System;
using System.Collections.Generic;

namespace ParrotFrankEntities.parrot_frank
{
    public partial class Categories
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime DateCreation { get; set; }
    }
}

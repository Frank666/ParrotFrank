using ParrotFrankInterfaces;
using System;
using System.Collections.Generic;

namespace ParrotFrankEntities.parrot_frank
{
    public partial class Subcategories: IEntity
    {
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public int Id { get; set; }
    }
}

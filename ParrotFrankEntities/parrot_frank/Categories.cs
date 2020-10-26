using ParrotFrankInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ParrotFrankEntities.parrot_frank
{
    public partial class Categories: IEntity
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime DateCreation { get; set; }
        public int Id { get; set; }
    }
}

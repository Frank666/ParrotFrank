using System;
using System.Collections.Generic;

namespace ParrotFrankAPI.Parrot_Frank
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }
        public string Secret { get; set; }
        public int Status { get; set; }
    }
}

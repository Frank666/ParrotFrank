using System;
using System.Collections.Generic;

namespace ParrotFrankAPI.parrot_frank
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nick { get; set; }
        public string Secret { get; set; }
        public int Status { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime LastAccess { get; set; }
        public string Token { get; set; }
        public DateTime? RefreshTime { get; set; }
        public string RefreshToken { get; set; }
    }
}

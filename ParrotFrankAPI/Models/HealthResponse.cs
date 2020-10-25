using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotFrankAPI.Models
{
    public class HealthResponse        
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Desc { get; set; }
        public DateTime ServerTime { get; set; }
    }
}

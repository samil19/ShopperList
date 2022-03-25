using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopperlist_backend.Common.DTOs
{
    public class ScaleDto
    {
        public int Id { get; set; }
        public int? Health { get; set; }
        public int? Cosmetic { get; set; }
        public int? Strength { get; set; }
        public int? Protein { get; set; }
        public int? Luxury { get; set; }
        public int? Needed { get; set; }
    }
}

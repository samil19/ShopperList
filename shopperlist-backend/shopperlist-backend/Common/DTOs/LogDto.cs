using System;
using System.Collections.Generic;

#nullable disable

namespace shopperlist_backend.Common.DTOs
{
    public partial class LogDto
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Reason { get; set; }
        public string Entity { get; set; }
        public int IdEntity { get; set; }
    }
}

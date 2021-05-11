using System;
using System.Collections.Generic;

#nullable disable

namespace TinyMan.Models
{
    public partial class UrlTable
    {
        public long Id { get; set; }
        public string LongUrl { get; set; }
        public string ShorlUrl { get; set; }
        public bool? IsExpired { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

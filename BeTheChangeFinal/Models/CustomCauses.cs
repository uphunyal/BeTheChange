using System;
using System.Collections.Generic;

namespace BeTheChangeFinal.Models
{
    public partial class CustomCauses
    {
        public int CustomId { get; set; }
        public string CustomName { get; set; }
        public string CustomDetails { get; set; }
        public string CustomLocation { get; set; }
        public string CauseType { get; set; }
        public string DonateLink { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BeTheChangeFinal.Models
{
    public partial class Disaster
    {
        public int DisasterId { get; set; }
        public string DisasterName { get; set; }
        public string DisasterDetails { get; set; }
        public string DisasterLocation { get; set; }
        public string DisasterLink { get; set; }
        public string Urgency { get; set; }
        public string DtypeName { get; set; }

        public virtual DisasterType DtypeNameNavigation { get; set; }
    }
}

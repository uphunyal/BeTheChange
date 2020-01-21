using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeTheChangeFinal.Models
{
    public partial class Disaster
    {
        public int DisasterId { get; set; }
        [Display(Name ="Disaster Name")]
        public string DisasterName { get; set; }
        [Display (Name = "Details")]
        public string DisasterDetails { get; set; }
        [Display(Name ="Location")]
        public string DisasterLocation { get; set; }
        [Display(Name ="Link")]
        public string DisasterLink { get; set; }
        [Display(Name ="Urgency")]
        public string Urgency { get; set; }
        [Display(Name ="Disaster Type")]
        public string DtypeName { get; set; }

        public virtual DisasterType DtypeNameNavigation { get; set; }
    }
}

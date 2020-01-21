using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeTheChangeFinal.Models
{
    public partial class Charity
    {
        public int CharityId { get; set; }
        [Display (Name="Details")]
        public string CharityDetails { get; set; }
        [Display(Name ="Charity Name")]
        public string CharityName { get; set; }
        [Display(Name ="Organization Name")]
        public string CharityOrganization { get; set; }
        [Display(Name ="Location")]
        public string CharityLocation { get; set; }
        [Display(Name ="Link")]
        public string CharityLink { get; set; }
        [Display(Name ="Charity Type")]
        public string CtypeName { get; set; }

        public virtual CharityType CtypeNameNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BeTheChangeFinal.Models
{
    public partial class Charity
    {
        public int CharityId { get; set; }
        public string CharityDetails { get; set; }
        public string CharityName { get; set; }
        public string CharityOrganization { get; set; }
        public string CharityLocation { get; set; }
        public string CharityLink { get; set; }
        public string CtypeName { get; set; }

        public virtual CharityType CtypeNameNavigation { get; set; }
    }
}

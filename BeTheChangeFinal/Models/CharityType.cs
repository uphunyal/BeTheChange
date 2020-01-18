using System;
using System.Collections.Generic;

namespace BeTheChangeFinal.Models
{
    public partial class CharityType
    {
        public CharityType()
        {
            Charity = new HashSet<Charity>();
        }

        public string CtypeName { get; set; }

        public virtual ICollection<Charity> Charity { get; set; }
    }
}

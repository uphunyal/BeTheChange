using System;
using System.Collections.Generic;

namespace BeTheChangeFinal.Models
{
    public partial class DisasterType
    {
        public DisasterType()
        {
            Disaster = new HashSet<Disaster>();
        }

        public string DtypeName { get; set; }

        public virtual ICollection<Disaster> Disaster { get; set; }
    }
}

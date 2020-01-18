using System;
using System.Collections.Generic;

namespace BeTheChangeFinal.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public string PostDetails { get; set; }
        public DateTime PostDate { get; set; }
        public string PostTitle { get; set; }
        public string UserEmail { get; set; }
    }
}

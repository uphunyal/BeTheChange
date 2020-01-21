using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeTheChangeFinal.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        [Display(Name = "Title")]
        public string PostTitle { get; set; }
        [Display(Name = "Date")]
        public DateTime PostDate { get; set; }
        [Display(Name = "Username")]
        public string UserEmail { get; set; }
        [Display(Name ="Details")]
        public string PostDetails { get; set; }
    }
}

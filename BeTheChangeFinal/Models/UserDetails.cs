using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeTheChangeFinal.Models
{
    public class UserDetails: IdentityUser
    {
        [Required]
        public string Name { get; set; }
       
    }
}

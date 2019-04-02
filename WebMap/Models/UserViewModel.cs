using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class UserViewModel
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public  string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(8)]
        public String Password { get; set; }
    }
}
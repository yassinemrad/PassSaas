using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMap.Models
{
    public class NotificationModels
    {
        [Key]
        public int id { get; set; }
        public String nom { get; set; }
        public User sender { get; set; }
        public User reciver { get; set; }
    }
}

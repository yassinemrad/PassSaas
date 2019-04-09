using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
   public class reclamation
    {
        public int id { get; set; }
        [Required]
        [MinLength(1)]
        public string objet { get; set; }
        [Required]
        [MinLength(1)]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public int etat { get; set; }
        public string date { get; set; }
        public int user { get; set; }

    }
}

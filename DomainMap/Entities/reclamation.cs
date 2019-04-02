using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
   public class reclamation
    {
        public int id { get; set; }
        public string objet { get; set; }
        public string description { get; set; }
        public int etat { get; set; }
        public string date { get; set; }
        public User user { get; set; }

    }
}

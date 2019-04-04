
using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class reclamationViewModel
    {
        public int id { get; set; }
        public string objet { get; set; }
        public string description { get; set; }
        public int etat { get; set; }
        public string date { get; set; }
        public int user { get; set; }
        public string username { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum Cathegory
    {
        Statistic, Banking, Commercial, Medical, Education, Autre
    }
    public class Projet
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
        public Cathegory cathegory { get; set; }
        public virtual ICollection<Module> modules { get; set; }

    }
}

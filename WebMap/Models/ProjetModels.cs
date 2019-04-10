using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMap.Models
{
    public enum CathegoryModels
    {
        Statistic, Banking, Commercial, Medical, Education, Autre
    }
    public class ProjetModels
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String description { get; set; }
        public Cathegory cathegory { get; set; }
        public string Photo { get; set; }
        //public int? ProjectId { get; set; }
        public int Budget { get; set; }
        public String ThemeColor { get; set; }
        public Boolean IsFullDay { get; set; }
        public virtual ICollection<Module> modules { get; set; }
        public int idmodul { get; set; }

    }
}


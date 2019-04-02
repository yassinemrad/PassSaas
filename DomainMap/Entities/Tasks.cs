using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum Etat { ToDo, Doing, Done }
    public class Tasks
    {

        [Key]
        public int id { get; set; }
        [Display(Name = "Nom du Tache")]
        public String name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description du tache")]
        public String description { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }
        [Display(Name = "Date limite pour cette Tache")]
        public DateTime date { get; set; }
        public String estimation { get; set; }
        public int realDuration { get; set; }
        [Display(Name = "Etat du Tache")]
        public Etat etat { get; set; }
        public Module modules { get; set; }
        public User user { get; set; }

    }
}


using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebMap.Models
{
    public class ModuleModels
    {
        [Key]
        public int id { get; set; }
        public String nom { get; set; }
        public Projet projet { get; set; }
        public String nomtask { get; set; }
        public virtual ICollection<Tasks> task { get; set; }
        public int idtask { get; set; }
        public int idprojet { get; set; }
        public int iduser { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

    }
}

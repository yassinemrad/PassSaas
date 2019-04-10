using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMap.Models
{

    public enum Etat
    { ToDo, Doing, Done }
    public class TasksModels
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
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateAjout { get; set; }
        public String estimation { get; set; }
        public int realDuration { get; set; }
        [Display(Name = "Etat du Tache")]
        public Etat etat { get; set; }
        public Module modules { get; set; }
        [Display(Name = "Affecté un utilisateur")]
        public int iduser { get; set; }
        public int idmodul { get; set; }
        public int iduserAffect { get; set; }
        public int idprojet { get; set; }
        [Display(Name = "cette Tache doit étre terminer dans ")]
        public String diff { get; set; }
        [Display(Name = "Il vous reste seulement ")]
        public String rest { get; set; }
        [Display(Name = "Nom responsable du module ")]
        public String nuser { get; set; }
        [Display(Name = "Nom de Module ")]
        public String nmod { get; set; }
        public User user { get; set; }
        [Display(Name = "l'utilisateur qui a le minimum des taches")]
        public int nbsome { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

    }
}
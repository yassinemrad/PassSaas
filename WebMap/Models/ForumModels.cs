using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMap.Models
{
    public enum Categorie { DotNet, JEE, C, python }
    public class ForumModels
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public string Author { get; set; }
        [EnumDataType(typeof(Categorie))]
        public Categorie Categorie { get; set; }
        [UIHint("tinymce_jquery_full"),AllowHtml] 
        public string Contenu { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
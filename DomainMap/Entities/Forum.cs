using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum Categorie { DotNet, JEE, C, python ,CSS, Autre }
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public string Author { get; set; }
        [EnumDataType(typeof(Categorie))]
        public Categorie Categorie { get; set; }
        [UIHint("tinymce_jquery_full")]
        public string Contenu { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}


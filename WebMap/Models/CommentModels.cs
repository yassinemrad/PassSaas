using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class CommentModels
    {
        [Key]
        public int Id { get; set; }
        public string ChampComment { get; set; }
        public User user { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Forum forum { get; set; }
    }
}
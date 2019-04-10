using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
  public class Comment
    {   [Key]
        public int Id { get; set; }
        public string ChampComment { get; set; }
        public Comment comments { get; set; }
        public User user { get; set; }
        public virtual ICollection<Comment> Comments{ get; set; }
        public Forum forum { get; set; }
    }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public class Message
    {
        [Key]
        public int id { get; set; }
        public String text { get; set; }
        public String from { get; set; }
        public String to { get; set; }
        public DateTime timeSend { get; set; }
        public int read { get; set; }
        public User sender { get; set; }
        public User reciverr { get; set; }
    }
}

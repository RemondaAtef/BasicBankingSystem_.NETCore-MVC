using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.DAL.Entities
{
    public class History
    {
        [Key]
        public int id { get; set; }

        public string Senderid { get; set; }
        public string SenderName { get; set; }
        public string receiverid { get; set; }
        public string ReceiverName { get; set; }
        public string amount { get; set; }
        public DateTime Date { get; set; } 
    }
}


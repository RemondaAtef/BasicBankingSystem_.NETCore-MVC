using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.DAL.Entities
{
    public class Customers
    {
        public string Account_Num { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Current_Balance { get; set; }
    }
}

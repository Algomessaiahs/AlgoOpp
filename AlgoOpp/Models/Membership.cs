using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgoOpp.Models
{
    public class Membership
    {
        //public int ID { get; set; }
        public string Est_Name { get; set; }
        public string Email_id { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
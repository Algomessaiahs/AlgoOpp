using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgoOpp.Models
{
    public class Membership
    {
        //public int Est_Id { get; set; }
        //public string Est_Name { get; set; }
        public string Est_Type { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email id is required")]
        
        public string Email_id { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
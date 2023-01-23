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
        //[Required(ErrorMessage = "Email id is required")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //                    ErrorMessage = "Please enter a valid email address")]
        public string Email_id { get; set; }
        //[RegularExpression("^ (?=.* [A-Za-z]) (?=.*d) [A-Za-zd] {6,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        //[Required(ErrorMessage = "Password id is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
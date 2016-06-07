using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApp.Models
{
    public class Address
    {
        
        [Display(Name = "Street 1")]
        public string Street1 { get; set; }
        [Display(Name = "Street 2(optional)")]
        public string Street2 { get; set; }
        [Display(Name = "City*")]
        //[Required]
        public string City { get; set; }
        [Display(Name = "State*")]
        //[Required]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string Zipcode { get; set; }
    }
}

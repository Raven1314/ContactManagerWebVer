using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisContactWebVer.Models
{
    public class BusinessContact
    {
        public int BusinessContactID { get; set; }
        [Display(Name = "First Name")]
        public string BFname { get; set; }
        [Display(Name = "Last Name")]
        public string BLname { get; set; }
        [Display(Name = "Email")]
        public string BEmail { get; set; }
        [Display(Name = "Business Tel")]
        public string BusTel { get; set; }
        [Display(Name = "Addr1")]
        public string BAddr1 { get; set; }
        [Display(Name = "Addr2")]
        public string BAddr2 { get; set; }
        [Display(Name = "Addr3")]
        public string BAddr3 { get; set; }
        [Display(Name = "Postcode")]
        public string BPostcode { get; set; }
        [Display(Name = "City")]
        public string BCity { get; set; }

    }
}

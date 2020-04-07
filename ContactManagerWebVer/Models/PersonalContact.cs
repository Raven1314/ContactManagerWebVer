using System.ComponentModel.DataAnnotations;

namespace ContactManagerWebVer.Models
{
    public class PersonalContact
    {
        public int PersonalContactID { get; set; }
        [Display(Name = "First Name")]
        public string PFname { get; set; }
        [Display(Name = "Last Name")]
        public string PLname { get; set; }
        [Display(Name = "Email")]
        public string PEmail { get; set; }
        [Display(Name = "Personal Tel")]
        public string PerTel { get; set; }
        [Display(Name = "Addr1")]
        public string PAddr1 { get; set; }
        [Display(Name = "Addr2")]
        public string PAddr2 { get; set; }
        [Display(Name = "Addr3")]
        public string PAddr3 { get; set; }
        [Display(Name = "Postcode")]
        public string PPostcode { get; set; }
        [Display(Name = "City")]
        public string PCity { get; set; }
    }

}

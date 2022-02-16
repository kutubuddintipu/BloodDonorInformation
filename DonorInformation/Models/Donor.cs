using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DonorInformation.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Required")]
        public int Mobile { get; set; }

        [Required(ErrorMessage ="Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Required")]     
        public int groupId { get; set; }

        [NotMapped]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
    }
}

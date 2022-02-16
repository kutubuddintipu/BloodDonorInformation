using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonorInformation.Models
{
    public class Group
    {
        [Key]
        public int groupId { get; set; }

        public string BloodGroup { get; set; }
    }
}

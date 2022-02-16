using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorInformation.Models
{
    public class DonorContext: DbContext
    {
        public DonorContext(DbContextOptions<DonorContext> options):base(options)
        {

        }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Group> BloodGroup { get; set; }
    }
}

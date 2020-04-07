using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactManagerWebVer.Models;
using HarrisContactWebVer.Models;

namespace ContactManagerWebVer.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }
        public DbSet<PersonalContact> PersonalContacts { get; set; }//Get Personal Contact info
        public DbSet<BusinessContact> BusinessContact { get; set; }//Get Business Contact info
    }
}

using ContactManagerWebVer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisContactWebVer.Data
{
    public class DbInitialiser : DbContext
    {
        public static void Initialise(ContactDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

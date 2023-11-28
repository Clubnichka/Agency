using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using agency.Models;

namespace agency.Data
{
    public class agencyContext : DbContext
    {
        public agencyContext (DbContextOptions<agencyContext> options)
            : base(options)
        {
        }
        public agencyContext()
        {
        }
        public DbSet<agency.Models.Employee> Employee { get; set; } = default!;

        public DbSet<agency.Models.Vacancy>? Vacancy { get; set; }

        public DbSet<agency.Models.Employer>? Employer { get; set; }

        public DbSet<agency.Models.Administrator>? Administrator { get; set; }

        public DbSet<agency.Models.Manager>? Manager { get; set; }
    }
}

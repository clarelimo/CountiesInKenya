using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenyanCounties.Models
{
    public class LegalContext : DbContext
    {
        public LegalContext(DbContextOptions<LegalContext> options)
            : base(options)
        {
        }

        public DbSet<County> counties { get; set; }
        public DbSet<SubCounty> SubCounty { get; set; }
        public DbSet<Ward> Ward { get; set; }
    }
}

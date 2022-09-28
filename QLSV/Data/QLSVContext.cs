using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLSV.Models;
using Microsoft.EntityFrameworkCore;
namespace QLSV.Data
{
    public class QLSVContext : DbContext
    {
        public QLSVContext()
        {
        }

        public QLSVContext(DbContextOptions<QLSVContext> options)
            : base(options)
        {
        }

        public DbSet<QLSV.Models.Employee> Employee { get; set; } = default!;
        public DbSet<QLSV.Models.Fresher>? Fresher { get; set; }
        public DbSet<QLSV.Models.Intern>? Intern { get; set; }
        public DbSet<QLSV.Models.Experience>? Experience { get; set; }
        public DbSet<QLSV.Models.Certificate>? Certificate { get; set; }
        public DbSet<QLSV.Models.FresherDTO> FresherDTO { get; set; }
        public DbSet<QLSV.Models.ExperienceDTO> ExperienceDTO { get; set; }
        public DbSet<QLSV.Models.InternDTO> InternDTO { get; set; }
    }
}
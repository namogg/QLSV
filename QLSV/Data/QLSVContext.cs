﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLSV.Models;

namespace QLSV.Data
{
    public class QLSVContext : DbContext
    {
        public QLSVContext (DbContextOptions<QLSVContext> options)
            : base(options)
        {
        }

        public DbSet<QLSV.Models.Employee> Employee { get; set; } = default!;

        public DbSet<QLSV.Models.Fresher>? Fresher { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCFExcercise.Models;

namespace EFCFExcercise.Data
{
    public class EFCFExcerciseContext : DbContext
    {
        public EFCFExcerciseContext (DbContextOptions<EFCFExcerciseContext> options)
            : base(options)
        {
        }

        public DbSet<EFCFExcercise.Models.Staff> Staff { get; set; } = default!;

        public DbSet<EFCFExcercise.Models.Title> Title { get; set; } = default!;
    }
}

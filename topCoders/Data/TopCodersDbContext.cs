using System;
using topCoders.Models;
using Microsoft.EntityFrameworkCore;


namespace topCoders.Data
{
    public class TopCodersDbContext: DbContext
    {
        public TopCodersDbContext(DbContextOptions<TopCodersDbContext> opt): base(opt)
        {}
        public DbSet<Coder> coders { get;set; }
    }
}
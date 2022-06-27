﻿using Persistence.Configurations.Pages;

namespace Persistence
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext
            (Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
        {
            //Database.EnsureCreated();
        }

        public Microsoft.EntityFrameworkCore.DbSet<Domain.Cms.Page> Pages { get; set; }

        protected override void OnConfiguring
            (Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating
            (Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(PageConfiguration).Assembly);
        }
    }
}

using System;
using System.Data.Entity;

namespace EmulationProcessing.dbmodels
{
    class ProcessingContext :DbContext
    {
        public ProcessingContext() :base("DbConnection") {}

        public DbSet<User> Users { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<AccessProvider> AccessProviders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessProvider>();
        }
    }
}

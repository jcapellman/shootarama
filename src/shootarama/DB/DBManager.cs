using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using shootarama.DB.Tables;

namespace shootarama.DB
{
    public class DBManager : DbContext
    {
        public DbSet<Players> Players { get; set; }
        
        public DbSet<Teams> Teams { get; set; }

        public DbSet<LocationNames> LocationNames { get; set; }

        public DbSet<TeamNames> TeamNames { get; set; }

        public DbSet<PlayerNames> PlayerNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Common.Constants.FILENAME_SQLITE_DB}");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var changeSet = ChangeTracker.Entries();

            if (changeSet == null)
            {
                return base.SaveChangesAsync(cancellationToken);
            }

            foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Member("Created").CurrentValue = DateTime.Now;
                        entry.Member("Active").CurrentValue = true;
                        break;
                }

                entry.Member("Modified").CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
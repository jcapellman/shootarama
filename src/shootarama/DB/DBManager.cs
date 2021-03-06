﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using shootarama.DB.Tables;

namespace shootarama.DB
{
    public class DBManager : DbContext
    {
        protected DbSet<Players> Players { get; set; }

        protected DbSet<Teams> Teams { get; set; }

        protected DbSet<LocationNames> LocationNames { get; set; }

        protected DbSet<TeamNames> TeamNames { get; set; }

        protected DbSet<PlayerNames> PlayerNames { get; set; }

        protected DbSet<Games> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Common.Constants.FILENAME_SQLITE_DB}");
        }

        public void Initialize()
        {
            Database.Migrate();
        }

        public void Delete<T>(T obj) where T : BaseTable
        {
            Set<T>().Remove(obj);
        }

        public async Task<T> SelectOneAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression = null) where T : BaseTable => await Set<T>().FirstOrDefaultAsync(expression);

        public List<T> SelectMany<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression = null) where T: BaseTable => Set<T>().Where(expression).ToList();

        public async Task<int> InsertOneAsync<T>(T obj) where T : BaseTable
        {
            Set<T>().Add(obj);

            return await SaveChangesAsync();
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
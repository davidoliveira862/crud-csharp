using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Data
{
   public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options){}

    public DbSet<Store> StoreImports { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Store>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                entry.Entity.Entrada = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}

}
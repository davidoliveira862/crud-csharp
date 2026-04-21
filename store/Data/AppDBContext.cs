using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Data
{
   public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options){}

    public DbSet<Store> StoreImports { get; set; }
}

}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicMigration.Context;

public class LlamaContext : DbContext
{
    public DbSet<Models.Hat> Hats { get; set; }
    public DbSet<Models.Llamas> Llamas { get; set; }
    public LlamaContext(DbContextOptions<LlamaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Llamas>().HasMany(x => x.Hats).WithMany(x => x.Llamas);

        base.OnModelCreating(modelBuilder);
    }
    
}

using BasicMigration.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class LlamaContextFactory : IDesignTimeDbContextFactory<LlamaContext>
{
    public LlamaContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LlamaContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=admin;Password=llamaadminpassword;Database=testllama");

        return new LlamaContext(optionsBuilder.Options);
    }
}

// See https://aka.ms/new-console-template for more information
using BasicMigration.Context;
using BasicMigration.Models;
using BasicMigration.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Linq.Expressions;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var connectionString = "Host=localhost;Port=5432;Username=admin;Password=llamaadminpassword;Database=testllama";

        using var connection = new NpgsqlConnection(connectionString);
        var builder = new DbContextOptionsBuilder<LlamaContext>();
        builder.UseNpgsql(connectionString);



        var context = new LlamaContext(builder.Options);
        context.Database.EnsureCreated();

        var repository = new Repository(new DbContextFactory<LlamaContext>(builder.Options));

        var hat = new Hat { Name = "Fedora", Color = "Black" };
        await repository.AddHat(hat);

        var hats = await repository.GetHats();
        foreach (var h in hats)
        {
            Console.WriteLine($"Hat: {h.Name} - {h.Color}");
        }
        var llama = new Llamas { Name = "Lenny" };
        await repository.AddLlama(llama);
        var llamas = await repository.GetLlamas();
        foreach (var l in llamas)
        {
            Console.WriteLine($"Llama: {l.Name}");
        }
        await repository.AddHatToLlama(hats[0].Id, llamas[0].Id);

        var l0 = await repository.GetLlama(llamas[0].Id);
        Console.WriteLine($"Llama: {l0.Name}"); 
        foreach (var h in l0.Hats)
        {
            Console.WriteLine($"Hat: {h.Name} - {h.Color}");
        }
        await repository.DeleteLLamaByName("Lenny");
        await repository.DeleteHatByName("Fedora");

    }

    public class DbContextFactory<TContext> : IDbContextFactory<LlamaContext> where TContext : DbContext
    {
        private readonly DbContextOptions<LlamaContext> _options;

        public DbContextFactory(DbContextOptions<LlamaContext> options)
        {
            _options = options;
        }

        public LlamaContext CreateDbContext()
        {
            return new LlamaContext(_options);
        }
    }
}
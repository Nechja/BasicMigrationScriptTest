using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMigration.Services;

public class Repository
{
    readonly Context.LlamaContext _context;
    public Repository(IDbContextFactory<Context.LlamaContext> contextFactory)
    {
        _context = contextFactory.CreateDbContext();
    }

    public async Task<List<Models.Hat>> GetHats()
    {
        return await _context.Hats.ToListAsync();
    }
    public async Task<Models.Hat> GetHat(int id)
    {
        return await _context.Hats.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Models.Hat> AddHat(Models.Hat hat)
    {
        _context.Hats.Add(hat);
        await _context.SaveChangesAsync();
        return hat;
    }
    public async Task<Models.Hat> UpdateHat(Models.Hat hat)
    {
        _context.Hats.Update(hat);
        await _context.SaveChangesAsync();
        return hat;
    }
    public async Task<Models.Hat> DeleteHat(int id)
    {
        var hat = await _context.Hats.FirstOrDefaultAsync(x => x.Id == id);
        _context.Hats.Remove(hat);
        await _context.SaveChangesAsync();
        return hat;
    }
    public async Task DeleteHatByName(string name)
    {
        var hat = await _context.Hats.FirstOrDefaultAsync(x => x.Name == name);
        _context.Hats.Remove(hat);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Models.Llamas>> GetLlamas()
    {
        return await _context.Llamas.ToListAsync();
    }
    public async Task<Models.Llamas> GetLlama(int id)
    {
        return await _context.Llamas.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Models.Llamas> AddLlama(Models.Llamas llama)
    {
        _context.Llamas.Add(llama);
        await _context.SaveChangesAsync();
        return llama;
    }
    public async Task<Models.Llamas> UpdateLlama(Models.Llamas llama)
    {
        _context.Llamas.Update(llama);
        await _context.SaveChangesAsync();
        return llama;
    }
    public async Task<Models.Llamas> DeleteLlama(int id)
    {
        var llama = await _context.Llamas.FirstOrDefaultAsync(x => x.Id == id);
        _context.Llamas.Remove(llama);
        await _context.SaveChangesAsync();
        return llama;
    }

    public async Task DeleteLLamaByName(string name)
    {
        var llama = await _context.Llamas.FirstOrDefaultAsync(x => x.Name == name);
        _context.Llamas.Remove(llama);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Models.Hat>> GetHatsForLlama(int llamaId)
    {
        var llama = await _context.Llamas.Include(x => x.Hats).FirstOrDefaultAsync(x => x.Id == llamaId);
        return llama.Hats;
    }
    public async Task<List<Models.Llamas>> GetLlamasForHat(int hatId)
    {
        var hat = await _context.Hats.Include(x => x.Llamas).FirstOrDefaultAsync(x => x.Id == hatId);
        return hat.Llamas;
    }
    public async Task<Models.Hat> AddHatToLlama(int llamaId, int hatId)
    {
        var llama = await _context.Llamas.Include(x => x.Hats).FirstOrDefaultAsync(x => x.Id == llamaId);
        var hat = await _context.Hats.FirstOrDefaultAsync(x => x.Id == hatId);
        llama.Hats.Add(hat);
        await _context.SaveChangesAsync();
        return hat;
    }
}

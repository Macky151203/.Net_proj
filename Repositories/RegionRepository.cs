namespace WebApplication1.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;
using WebApplication1.Data;

public class RegionRepository : IRegionRepository
{
    private readonly ProjDBcontext _dbContext;

    public RegionRepository(ProjDBcontext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Regions>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Regions> GetByIdAsync(Guid id)
    {
        return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Regions regions)
    {
        await _dbContext.Regions.AddAsync(regions);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var region = await GetByIdAsync(id);
        if (region != null)
        {
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task<Regions> UpdateAsync(Guid id, Regions updatedRegion)
    {
        var existingRegion = await GetByIdAsync(id);
        if (existingRegion != null)
        {
            existingRegion.Code = updatedRegion.Code;
            existingRegion.Name = updatedRegion.Name;
            existingRegion.Regionimageurl = updatedRegion.Regionimageurl;
            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
        return null;
    }
}   
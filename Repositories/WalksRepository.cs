namespace WebApplication1.Repositories;     
using WebApplication1.Models.Domain;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

public class WalksRepository : IWalksRepository{
    private readonly ProjDBcontext _dbContext;
    public WalksRepository(ProjDBcontext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Walks>> GetAllAsync(string? filteron=null,string? filterquery=null)
    {
        //filtering
        var walks=_dbContext.Walks.AsQueryable();
        if(!string.IsNullOrWhiteSpace(filteron) && !string.IsNullOrWhiteSpace(filterquery)){
            if(filteron.ToLower()=="name"){
                walks=walks.Where(x=>x.Name.ToLower().Contains(filterquery.ToLower()));
            }
        }
        return await walks.ToListAsync();
    }
    public async Task CreateAsync(Walks walks){
        await _dbContext.Walks.AddAsync(walks);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Walks> GetByIdAsync(Guid id){
        return await _dbContext.Walks.FirstOrDefaultAsync(x=>x.Id==id);
    }
    public async Task DeleteAsync(Guid id){
        var walks=await GetByIdAsync(id);
        if(walks!=null){
            _dbContext.Walks.Remove(walks);
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task<Walks> UpdateAsync(Guid id,Walks updatedwalks){
        var existingwalks=await GetByIdAsync(id);
        if(existingwalks!=null){
            existingwalks.Name=updatedwalks.Name;
            existingwalks.Description=updatedwalks.Description;
            existingwalks.Length=updatedwalks.Length;
            existingwalks.RegionId=updatedwalks.RegionId;
            existingwalks.DifficultyId=updatedwalks.DifficultyId;
            existingwalks.WalkImageUrl=updatedwalks.WalkImageUrl;
            await _dbContext.SaveChangesAsync();
            return existingwalks;
        }
        return null;
    }
}
namespace WebApplication1.Repositories;
using WebApplication1.Models.Domain;

public interface IRegionRepository
{
    Task<List<Regions>> GetAllAsync();
    Task<Regions> GetByIdAsync(Guid id);
    Task CreateAsync(Regions regions);
    Task DeleteAsync(Guid id);
    Task<Regions> UpdateAsync(Guid id, Regions regions);
}
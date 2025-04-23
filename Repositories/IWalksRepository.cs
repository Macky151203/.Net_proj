namespace WebApplication1.Repositories;
using WebApplication1.Models.Domain;

public interface IWalksRepository
{
    Task<List<Walks>> GetAllAsync(string? filteron=null, string? filterquery=null);   
    Task<Walks> GetByIdAsync(Guid id);
    Task CreateAsync(Walks walks);
    Task DeleteAsync(Guid id);
    // Task CreateAsync(Walks walks);
    // Task DeleteAsync(Guid id);
    Task<Walks> UpdateAsync(Guid id, Walks walks);
}
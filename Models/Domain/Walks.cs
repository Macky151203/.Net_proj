namespace WebApplication1.Models.Domain;
using System.ComponentModel.DataAnnotations;
public class Walks{
    public Guid Id { get; set; }
    [Required]
    [MinLength(2 ,ErrorMessage="Name must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } 
    [Required]

    public string Description { get; set; } 
    [Required]
    [Range(0,10)]
    public double Length { get; set; } 
    public string? WalkImageUrl { get; set; } 
    public Guid RegionId { get; set; } 
    public Guid DifficultyId { get; set; } 
    //navigation properties
    // public Regions Region { get; set; } 
    // public Difficulty Difficulty { get; set; }
}
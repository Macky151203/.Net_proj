namespace WebApplication1.Models.Domain;

public class Regions{
    public Guid Id { get; set; }
    public string Code { get; set; } 
    public string Name { get; set; } 
    public string? Regionimageurl { get; set; } 
    public Regions(Guid id, string code, string name, string? regionimageurl = null)
    {
        Id = id;
        Code = code;
        Name = name;
        Regionimageurl = regionimageurl;
    }
}
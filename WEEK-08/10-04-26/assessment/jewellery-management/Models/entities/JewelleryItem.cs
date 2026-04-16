namespace JewelleryApi.Models.entities;

public class JewelleryItem
{
    public Guid Id{get; set;}
    public string Name{get; set;}= string.Empty;

    public string Material{get; set;} = string.Empty;
    public string Category{ get; set;} = string.Empty;
    public decimal Price{ get; set;}

    public int Quantity{ get; set;}
} 
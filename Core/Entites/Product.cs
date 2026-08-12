namespace Core.Entites;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string Type { get; set; }
    public required string Brand { get; set; } //ماركة
    public required string QuantityInStock { get; set; }  //الكمية المتوفرة في المخزن
}

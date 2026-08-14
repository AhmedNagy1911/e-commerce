using Core.Entites;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(string? brand , string? type) : base(x=>
    (string.IsNullOrEmpty(brand) || x.Brand== brand) &&
    (string.IsNullOrEmpty(type) || x.Type == type)
    )
    {
    }
}

using Core.Entites;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecParams productParams) : base(x=>
    (!productParams.Brands.Any() || productParams.Brands.Contains(x.Brand)) &&
            (!productParams.Types.Any() || productParams.Types.Contains(x.Type)))
    {
        switch (productParams.Sort)
        {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;

                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;

                default:
                AddOrderBy(p => p.Name);
                break;
        }
    }
}

using Core.Entites;

namespace Core.Specifications;

public class BrandListSpeification : BaseSpecification<Product, string>
{
    public BrandListSpeification() 
    {
        AddSelect(x => x.Brand);
        ApplyDistinct();
    }
}

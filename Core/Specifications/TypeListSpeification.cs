using Core.Entites;

namespace Core.Specifications;

public class TypeListSpeification : BaseSpecification<Product, string>
{
    public TypeListSpeification()
    {
        AddSelect(x => x.Type);
        ApplyDistinct();
    }
}

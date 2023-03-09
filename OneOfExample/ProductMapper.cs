using AutoMapper;

namespace OneOfExample;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
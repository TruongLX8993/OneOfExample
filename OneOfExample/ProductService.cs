using AutoMapper;
using OneOf;

namespace OneOfExample;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public ProductDto CreateProduct(string name, string code, string sku)
    {
        var product = new Product()
        {
            Name = name,
            Code = code,
            Sku = sku,
        };
        _productRepository.Add(product);
        return ToDto(product);
    }

    public OneOf<ProductDto, NotFoundException> GetById(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
            return new NotFoundException();
        return ToDto(product);
    }

    private ProductDto ToDto(Product product)
    {
        return _mapper.Map<ProductDto>(product);
    }
}
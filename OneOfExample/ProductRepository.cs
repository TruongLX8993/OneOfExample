namespace OneOfExample;

public class ProductRepository : IProductRepository
{
    private readonly IList<Product> _products = new List<Product>();

    public void Add(Product product)
    {
        var maxId = _products.Any() ? _products.Max(x => x.Id) : 0;
        var newId = maxId + 1;
        product.Id = newId;
        _products.Add(product);
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(x => x.Id == id);
    }
}
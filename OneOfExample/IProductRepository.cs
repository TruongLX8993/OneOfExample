namespace OneOfExample;

public interface IProductRepository
{
    void Add(Product product);
    Product? GetById(int id);
}
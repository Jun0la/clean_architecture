using CleanArchMvc.Domain.entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
         Task<Product> GetById(int? id);
         Task<Product> GetProductCategoryAsync(int? id);

         Task<Product> Create(Product product);
         Task<Product> Update(Product product);
         Task<Product> Remove(Product product);
    }
}
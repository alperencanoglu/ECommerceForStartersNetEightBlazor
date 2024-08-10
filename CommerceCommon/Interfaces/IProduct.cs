using CommerceCommon.Model;

namespace CommerceCommon.Interfaces;

public interface IProduct
{
  Task<Response.Response> AddProduct(Product RequestObject);
  Task<List<Product>> GetAllProducts(bool featured);
}
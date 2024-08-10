using CommerceCommon.Interfaces;
using CommerceCommon.Response;
using ECommerceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRepositories.Product;

public class ProductRepository : IProduct
{
    private readonly ApplicationDbContext ApplicationDbContext;

    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        this.ApplicationDbContext = applicationDbContext;
    }

    public async Task<Response> AddProduct(CommerceCommon.Model.Product RequestObject)
    {
        if (RequestObject is null) return new Response(false, "Request is null");
        var (status, msg) = await CheckProduct(RequestObject.Name!);

        if (status)
        {
            ApplicationDbContext.Products.Add(RequestObject);
            await Commit();
            return new Response(true, "Succeed");
        }


        return new Response(false, "Already Exists");
    }

    public async Task<List<CommerceCommon.Model.Product>> GetAllProducts(bool featured)
    {
        if (featured)
        {
            return await 
                ApplicationDbContext.Products.Where(x => x.Featured == true).ToListAsync();
        }
        else
        {
            return await ApplicationDbContext.Products.ToListAsync();
        }
    }


    private async Task<Response> CheckProduct(string name)
    {
        CommerceCommon.Model.Product product =
            await this.ApplicationDbContext.Products.FirstOrDefaultAsync(x =>
                x.Name.ToLower() == name.ToLower());
        return product is null ? new Response(true, null) : new Response(false, "Already Exists!");
    }

    private async Task Commit() => await ApplicationDbContext.SaveChangesAsync();
}